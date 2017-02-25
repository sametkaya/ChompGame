using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chomp.Models
{
    public class Item
    {
        //kordinat x
        public int X { get; set; }
        //kordinat y
        public int Y { get; set; }
        // item tipi yenilebilir yenilemez O yenilir veya X yenilmez
        public char Type { get; set; }
        //yenildi
        public bool isEaten { get; set; }
        //item style resim yüklemek için kullanılıyor
        public int ItemStyle { get; set; }
        //hangi oyuncunun yediği
        public bool isEatenByFirstGamer { get; set; }
        //yapıcı metod
        public Item()
        {

            this.Type = 'O';
            this.isEaten = false;
        }
    }
}