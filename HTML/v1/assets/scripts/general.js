$(document).ready(function () {

  // + menu btn   
  $(".menuBtn").click(function () {
    $(this).find("#nav-icon").toggleClass("open");
    $("header").toggleClass("active");
    $(".menuArea").fadeToggle();
  });
  // - menu btn 

  // + menu mobile   
  if($(window).width() < 980){
    $(".menuArea ul li h3").click(function () {
      if ($(this).next(".link").is(':visible')) {
        $(".menuArea ul li .link").slideUp();
      }
      else {
        $(".menuArea ul li .link").slideUp();
        $(this).next(".link").slideDown();
      }
    });
  }
 
  // - menu mobile 

  // + home slider 
  if ($(".homeSlider").length > 0) {

    $('.homeSlider').owlCarousel({
      loop: true,
      autoplay: true,
      margin: 0,
      responsiveClass: true,
      responsive: {
        0: { items: 1 }
      }
    })
  }
  // - home slider

  // + home prooduct slider
  if ($(".homeProductSlider").length > 0) {
    $('.homeProductSlider').owlCarousel({
      loop: true,
      margin: 0,
      autoplay: false,
      center: true,
      responsiveClass: true,
      nav: true,
      navText: ["", ""],
      dots: false,
      responsive: {
        0: { items: 1 },
        580: { items: 3 }
      }
    })
  }
  // - home product slider

  // + product icon lightbox
  if ($(".homeProductSlider").length > 0) {
    if ($(window).width() > 580) {
      $(".homeProduct .item .icon").click(function () {
        var id = $(this).attr("lightbox")
        console.log(id)
        $(".productLightBox").addClass("active");
        $(".productLightBox .content." + id + " ").addClass("active");
      });
      $(".productLightBox .content .close").click(function () {
        $(".productLightBox, .productLightBox .content").removeClass("active");
      });
    }
  }
  // - product icon lightbox

  // + home about slider
  if ($(".homeAboutSlider").length > 0) {
    $('.homeAboutSlider').owlCarousel({
      loop: true,
      margin: 0,
      autoplay: true,
      center: true,
      responsiveClass: true,
      nav: true,
      navText: ["", ""],
      dots: false,
      responsive: {
        0: { items: 1 }
      }
    })
  }
  // - home about slider

  // + home about animation
  if ($(".homeChange").length > 0) {
    $(".homeChange .textArea p").click(function () {

   
      $(".homeChange .img01, .homeChange .img02, .homeChange .img03, .homeChange .img04").fadeOut("slow");

      if($('.homeChange .imgArea .img04').is(':visible')){
        $('.homeChange .imgArea .img01').next("img").fadeIn();
      }
      else {
        $('.homeChange .imgArea img:visible').next("img").fadeIn();
      }

      if ($(".homeChange .textArea p").eq(0).hasClass("active")) {
        $(".homeChange .textArea p").removeClass("active")
        $(".homeChange .textArea p").eq(1).addClass("active");
     //   $(".homeChange .img03, .homeChange .img01").fadeToggle("slow");
      }
       else if ($(".homeChange .textArea p").eq(1).hasClass("active")) {
        $(".homeChange .textArea p").removeClass("active")
        $(".homeChange .textArea p").eq(2).addClass("active");
     //   $(".homeChange .img01, .homeChange .img02").fadeToggle("slow");
      }
       else if ($(".homeChange .textArea p").eq(2).hasClass("active")) {
        $(".homeChange .textArea p").removeClass("active")
        $(".homeChange .textArea p").eq(0).addClass("active");
    //    $(".homeChange .img02, .homeChange .img03").fadeToggle("slow");
      }

    });
  }
  // - home about animation

  // + contact form
  if ($(".contactForm").length > 0) {
    $(".contactForm").validate({
      rules: {
        name: "required",
        phone: "required",
        message: "required",
        company: "required",
        email: {
          required: true,
          email: true
        }
      },
      invalidHandler: function (e, r) {
      },
      submitHandler: function (e) {
      }
    })
  }
  // - contact form

  // + register form
  if ($(".registerForm").length > 0) {
    $(".registerForm").validate({
      highlight: function(element) {
        $(element).parent().addClass("field-error");
        },
        unhighlight: function(element) {
            $(element).parent().removeClass("field-error");
        },
      rules: {
        tckn: "required",
        name: "required",
        surname: "required",
        email: {
          required: true,
          email: true
        },
        pass: "required",
        passAgain: {
          equalTo: "#pass"
        },
        check01: "required",
        check02: "required",
        "hiddenRecaptcha": {
          required: function() {
              if(grecaptcha.getResponse() == '') {
                  return true;
              } else {
                  return false;
              }
          }
      }
      },
      messages: {
        "hiddenRecaptcha": "Lütfen Google doğrulama adımını boş bırakmayınız."
    },
      invalidHandler: function (e, r) { },
      submitHandler: function (e) { }
    })
  }
  // - register form

// + form contact
if ($(".formContact").length > 0) {
  $(".formContact").validate({
    highlight: function(element) {
      $(element).parent().addClass("field-error");
      },
      unhighlight: function(element) {
          $(element).parent().removeClass("field-error");
      },
    rules: {
      name: "required",
      surname: "required",
      email: {
        required: true,
        email: true
      },
      company: "required",
      phone: "required",
      check01: "required",
      check02: "required",
      "hiddenRecaptcha": {
        required: function() {
            if(grecaptcha.getResponse() == '') {
                return true;
            } else {
                return false;
            }
        }
    }
    },
    messages: {
      "hiddenRecaptcha": "Lütfen Google doğrulama adımını boş bırakmayınız."
  },
    invalidHandler: function (e, r) { },
    submitHandler: function (e) { }
  })
}
// - form contact

// + form productForm
if ($(".productForm").length > 0) {
  $(".productForm").validate({
    highlight: function(element) {
      $(element).parent().addClass("field-error");
      },
      unhighlight: function(element) {
          $(element).parent().removeClass("field-error");
      },
    rules: {
      name: "required",
      surname: "required",
      email: {
        required: true,
        email: true
      },
      company: "required",
      product: "required",
      phone: "required",
      message: "required",
      check01: "required",
      check02: "required"
    },
    invalidHandler: function (e, r) { },
    submitHandler: function (e) { }
  })
}
// - form productForm


  // + product request
  $(".formOpen, .productRequest .close").click(function () {
  //  $(".productRequest").toggleClass("onlyMoblile")
    $(".productRequest .formOpen").slideToggle("fast");
    $(".productRequest #formArea").slideToggle();
    $("html, body").animate({ scrollTop: $('#formArea').offset().top }, 1000);
  });
  // - product Request

  // + switch
  $('input.lcs_check').lc_switch();
  $(document).on('lcs-off', '.lcs_check', function () {
    var subj = ($(this).attr('type') == 'radio') ? 'radio #' : 'checkbox #',
      num = $(this).val();
    $('#third_div ul').prepend('<li><em>[lcs-off]</em>' + subj + num + ' is unchecked</li>');
  });
  // - switch

  // + select 2
  if ($(".customSelect").length > 0) {
    $('.customSelect').select2({
      minimumResultsForSearch: Infinity
    });
  }
  // - select 2

  // + checkbox
  $(".customCheck").click(function () {
    if ($(this).hasClass("active")) {
      $(this).removeClass("active");
      $(this).closest(".checkArea ").find("input").attr('checked', false);
    }
    else {
      $(this).addClass("active");
      $(this).closest(".checkArea ").find("input").attr('checked', true);
    }

  });
  // - checkbox

  // + login lightbox
  $(".loginBtn, .loginArea .close").click(function () {
    $(".loginArea").toggleClass("active")
  });
  // - login lightbox

  // + accordion 
  if ($(".accordion").length > 0) {
    $(".accordion li .aTitle").click(function () {
      var item = $(this).closest("li")
      if (item.hasClass("active")) {
        item.find(".aDetail").slideToggle();
        item.toggleClass("active");
      }
      else {
        $(".accordion li").removeClass("active")
        $(".accordion li .aDetail").slideUp();
        item.toggleClass("active");
        item.find(".aDetail").slideToggle();
      }
    });
  }
  // - accordion 

  // + video fix
  if ($(".video").length > 0) {
    $("video").fitVids();
  }
  // - video fix

  // + product detail slide
  if ($(".productSlideBox").length > 0) {
    $('.productSlideBox .owl-carousel ').owlCarousel({
      center: true,
      items: 2,
      loop: true,
      margin: 0,
      dots: false,
      autoWidth: true,
      nav: true,
      navText: ["", ""],
      responsive: {
        0: { items: 3 },
        500: { items: 4 },
        600: { items: 6 }
      }
    })
  }
  // - product detail slide

  // + productServices
  if ($(".productDetail").length > 0) {
    $('.productDetail .owl-carousel ').owlCarousel({
      center: true,
      items: 2,
      loop: true,
      margin: 0,
      mouseDrag: false,
      touchDrag: false,
      pullDrag: false,
      freeDrag:false,
      dots: false,
      autoWidth: true,
      nav: true,
      autoplay: false,
      navText: ["", ""],
      responsive: {
        0: { items: 3 },
        500: { items: 4 },
        600: { items: 6 }
      }
    });
    $(".owl-nav .owl-prev, .owl-nav .owl-next").click(function(){
      var item = $(".productDetail .owl-item.center .icon").attr("btn")
      $(".serviceItems").hide();
      if(item == "my-serbest-meslek-makbuzu") {
        $(".serviceItems[content=mikro-kep-2]").show();
      }
      $(".serviceItems[content="+ item +"]").show();
      $(".serviceItems[content="+ item +"]").next(".serviceItems").show();
    });
  }
  // - productServices

    // + aboutPage fix
    if ($(".aboutPage").length > 0) {
      var header = $("header").outerHeight()
      var head = $(".headTitle").outerHeight()
      var about = $(".aboutPage").outerHeight()
      var socail = $(".socialLink").outerHeight()
      var footer = $("footer").outerHeight()
      var toplam = head + footer + socail + header + about
      if($(window).height() > toplam ) {
        $(".aboutPage").css("padding-bottom", $(window).height() - toplam - 55 )
      }
    }
    // - aboutPage fix


    // + errorPage fix
    if ($(".errorPage").length > 0) {
      var header = $("header").outerHeight()
      var head = $(".headTitle").outerHeight()
      var about = $(".whiteContent").outerHeight()
      var socail = $(".socialLink").outerHeight()
      var footer = $("footer").outerHeight()
      var toplam = head + footer + socail + header + about
      if($(window).height() > toplam ) {
        $(".errorPage").css("padding-bottom", $(window).height() - toplam - 50 )
      }
    }
    // - errorPage fix

    // + register fix
    if ($(".registerArea").length > 0) {
      var header = $("header").outerHeight()
      var about = $(".registerArea").outerHeight()
      var socail = $(".socialLink").outerHeight()
      var footer = $("footer").outerHeight()
      var toplam =  footer + socail + header + about
      if($(window).height() > toplam ) {
        $(".registerArea").css("padding-bottom", $(window).height() - toplam - 14 )
      }
    }
    // - errorPage fix

});

$(window).resize(function () {

});
