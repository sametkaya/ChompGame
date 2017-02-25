
$(document).ready(function () {
    // create NumericTextBox from input HTML element
    $(".numeric").kendoNumericTextBox({
        format: "#",
        min: 3,
        max: 20,
        step: 1
    });



    $('#game-table tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });
  
  
    //$(".StartGameButton").kendoButton();
    //var button = $(".StartGameButton").data("kendoButton");
    //button.bind("click", function (e) {

    //    var gx = $("#x").attr("aria-valuenow");
    //    var gy = $("#y").attr("aria-valuenow");

    //    $.ajax({
    //        type: "POST",
    //        dataType: "json",
    //        data: { x: gx, y: gy },
    //        url: '@Url.Action("StartGame", "Home")',
    //        success: function (result) {

    //            alert("dsds");

    //        },
    //        error: function (jqXHR, textStatus, errorThrown) {
    //            //alert('error!');

    //            $('#content').html(jqXHR.responseText);
    //            //$('#content').html('<p>status code: ' + jqXHR.status + '</p><p>errorThrown: ' + errorThrown + '</p><p>jqXHR.responseText:</p><div>' + jqXHR.responseText + '</div>');
    //            //console.log('jqXHR:');
    //            //console.log(jqXHR);
    //            //console.log('textStatus:');
    //            //console.log(textStatus);
    //            //console.log('errorThrown:');
    //            //console.log(errorThrown);
    //        }



    //    });

    //});



});


