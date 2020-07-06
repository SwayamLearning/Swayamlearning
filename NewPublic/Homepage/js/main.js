//let ncount=function(selector){
    
//    $(selector).each(function()
//    {
//        $(this).animate({
//            Counter:$(this).text()
//        },{
//            duration:5000,
//            easing:"swing",
//            step:function(value){
//                $(this).text(Math.ceil(value));
//            }
        
//        });
//    });
//};
//let a=0;
//$(window).scroll(function()
//{
//    let oTop =$('.extra-features').height();
//   // let oTop=$(".numbers").offset().top-window.innerHeight;
//   console.log(oTop);
//    if((a==0)&&$(window).scrollTop()>=oTop)
//    {
        
//        a++;
//        ncount(".rect>h2");
         

//    }
//    // else
//    // {
        
//    //     ncount(".rect>h2");
         
//    // }
//})
var a1 = 0;
$(window).scroll(function() {

    var oTop = $('#counter').offset().top - window.innerHeight;
    alert(oTop);
    if (a1 == 0 && $(window).scrollTop() > oTop) {
        alert("inside if");
        $('.counter-value').each(function() {
            var $this = $(this),
              countTo = $this.attr('data-count');
            $({
                countNum: $this.text()
            }).animate({
                countNum: countTo
            },

              {

                  duration: 7000,
                  easing: 'swing',
                  step: function() {
                      $this.text(Math.floor(this.countNum));
                  },
                  complete: function() {
                      $this.text(this.countNum);
                      //alert('finished');
                  }

              });
        });
        a1 = 1;
    }

});