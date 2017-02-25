using Chomp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chomp.Models
{
    public class MatrixTable
    {
        // item tablosu
        public Item[,] Table { get; set; } 
        //henüz yenilmemiş itemler
        public List<Item> EatableItems { get; set; }
        //enson zehirli item
        public Item lastItem;
        //item tablosu oluşturma
        public MatrixTable(int SizeX, int SizeY)
        {
            //random sınıı
            Random rnd = new Random();
            EatableItems = new List<Item>();
            this.Table = new Item[SizeX, SizeY];
          //tablo oluşturuluyor
            for (int i = 0; i < this.Table.GetLength(0); i++)
            {
                int t = this.Table.GetLength(1);
                for (int j = 0; j < this.Table.GetLength(1); j++)
                {

                    this.Table[i, j] = new Item();// item oluştu
                    this.Table[i, j].ItemStyle = rnd.Next(1,11);// iteme yenilebir bir resim indexi
                    this.Table[i, j].Y = i; //lokasyon
                    this.Table[i, j].X = j; // lokasyon
                    EatableItems.Add(this.Table[i, j]); // obje referansı yenilebilir listeye de eklendi
                }
            }
            this.Table[SizeX - 1, SizeY - 1].Type = 'X'; //sağ en alt köşe yenilemez olarak işaretlendi
            this.Table[SizeX - 1, SizeY - 1].ItemStyle = rnd.Next(1, 4); // yenilemez resim indexi
            this.lastItem = this.Table[SizeX - 1, SizeY - 1]; // yenilemez itemin obje referansı
            EatableItems.Remove(this.Table[SizeX - 1, SizeY - 1]); // yenilemez itemi yenilebilir listeden çıkarıyoruz



        }
        // bir item yeme fonsiyonu
        public void EatLeft(int X, int Y)
        {
            for (int i = 0; i <= X; i++)
            {
                for (int j = 0; j <= Y; j++)
                {
                    if ( this.Table[j, i].isEaten) // eğer yenilmişse geri dön
                    {
                        continue;
                    }
                    this.Table[j, i].isEaten = true; // yenilmemişse yenildi artık
                    //kim tarafından yenildiği
                    this.Table[j, i].isEatenByFirstGamer = HomeController.PlayerTurn;
                    // yenilebilir listesinden çıkar
                    EatableItems.Remove(this.Table[j, i]);
                }
            }
            // eğer yenilebilir item kalmamışsa oyun  biter
            if (EatableItems.Count<= 0)
            {
                // son kalan son zehirli itemi yer
                this.lastItem.isEatenByFirstGamer = !HomeController.PlayerTurn;
            }
        
        }

        //bilgisayarın hamle yapma fonksiyonu
        public void ComputerEatRandom()
        {
            if (this.EatableItems.Count>0)
            {
                Random rnd = new Random();
                // random bir item seç
                int itemindex = rnd.Next(0, this.EatableItems.Count);
                //itemi ye
                Item eat = this.EatableItems[itemindex];
                this.EatLeft(eat.X, eat.Y);  
                
            }
        
        }

    }
}