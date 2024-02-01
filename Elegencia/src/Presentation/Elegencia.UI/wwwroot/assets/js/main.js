(function ($) {
  ("use strict");

  /*
|--------------------------------------------------------------------------
| Template Name: Elegencia
| Author: Thememarch
| Version: 1.0.0
|--------------------------------------------------------------------------
|--------------------------------------------------------------------------
| TABLE OF CONTENTS:
|--------------------------------------------------------------------------
| 1. Preloader
| 2. Mobile Menu
| 3. Sticky Header
| 4. Dynamic Background
| 5. Slick Slider
| 6. Modal Video
| 7. Social Button Hover
| 8. Light Gallery
| 9. Comming soon
| 10. Scroll Up
| 11. Gsap Register Plugin
| 12. Heder Border Animations
| 13. Comming Soon and Error Pages Border Animations
| 14. Top Header Slider Bar
| 15. Images Overlap
| 16. About Section Border Animations
| 17. Portfolio Details Animations
| 18. Food Menu Animations
| 19. Footer Animations
| 20. loaction Section border Animitions
| 21. Images Zoom In and Out Animitions
| 22. Title Animation
| 23. Hover Show Images
| 24. Scroll Down To Top Animation
| 25. Scroll Effect Blog Details Page


    /*--------------------------------------------------------------
    Scripts initialization
--------------------------------------------------------------*/
  $.exists = function (selector) {
    return $(selector).length > 0;
  };

  $(window).on("load", function () {
    $(window).trigger("scroll");
    $(window).trigger("resize");
    preloader();
  });

  $(function () {
    $(window).trigger("resize");
    mainNav();
    stickyHeader();
    dynamicBackground();
    swiperInit();
    modalVideo();
    hoverTab();
    scrollUp();
  });

  $(window).on("scroll", function () {
    showScrollUp();
  });
  /*-------------------------------------------------
      1. preloader  
 --------------------------------------------------------------*/

  function preloader() {
    setTimeout(function () {
      $("#ak-preloader").addClass("loaded");

      if ($("#ak-preloader").hasClass("loaded")) {
        $("#preloader")
          .delay(800)
          .queue(function () {
            $(this).remove();
          })
          .fadeOut();
      }
    }, 1000);
  }
  /*--------------------------------------------------------------
     2. Mobile  Menu  
 -----------------------------------------------------------------*/
  function mainNav() {
    $(".ak-nav").append('<span class="ak-munu_toggle"><span></span></span>');
    $(".menu-item-has-children").append(
      '<span class="ak-munu_dropdown_toggle"></span>'
    );
    $(".ak-munu_toggle").on("click", function () {
      $(this)
        .toggleClass("ak-toggle_active")
        .siblings(".ak-nav_list")
        .slideToggle();
    });
    $(".ak-munu_dropdown_toggle").on("click", function () {
      $(this).toggleClass("active").siblings("ul").slideToggle();
      $(this).parent().toggleClass("active");
    });

    $(".menu-item-has-black-section").append(
      '<span class="ak-munu_dropdown_toggle_1"></span>'
    );

    $(".ak-munu_dropdown_toggle_1").on("click", function () {
      $(this).toggleClass("active").siblings("ul").slideToggle();
      $(this).parent().toggleClass("active");
    });

    $(".ak-mode_btn").on("click", function () {
      $(this).toggleClass("active");
      $("body").toggleClass("ak-dark");
    });
    // Side Nav
    $(".ak-icon_btn").on("click", function () {
      $(".ak-side_header").addClass("active");
    });
    $(".ak-close, .ak-side_header_overlay").on("click", function () {
      $(".ak-side_header").removeClass("active");
    });
    //  Menu Text Split
    $(".ak-animo_links > li > a").each(function () {
      let xxx = $(this).html().split("").join("</span><span>");
      $(this).html(`<span class="ak-animo_text"><span>${xxx}</span></span>`);
    });
  }
  /*--------------------------------------------------------------
     3. Sticky Header
--------------------------------------------------------------*/
  function stickyHeader() {
    var $window = $(window);
    var lastScrollTop = 0;
    var $header = $(".ak-sticky_header");
    var headerHeight = $header.outerHeight() + 30;

    $window.scroll(function () {
      var windowTop = $window.scrollTop();

      if (windowTop >= headerHeight) {
        $header.addClass("ak-gescout_sticky");
      } else {
        $header.removeClass("ak-gescout_sticky");
        $header.removeClass("ak-gescout_show");
      }

      if ($header.hasClass("ak-gescout_sticky")) {
        if (windowTop < lastScrollTop) {
          $header.addClass("ak-gescout_show");
        } else {
          $header.removeClass("ak-gescout_show");
        }
      }

      lastScrollTop = windowTop;
    });
  }

  /*--------------------------------------------------------------
     4. Dynamic Background
-------------------------------------------------------------*/
  function dynamicBackground() {
    $("[data-src]").each(function () {
      var src = $(this).attr("data-src");
      $(this).css({
        "background-image": "url(" + src + ")",
      });
    });
  }

  /*--------------------------------------------------------------    
     5. Slick Slider
 --------------------------------------------------------------*/

  function swiperInit() {
    if ($.exists(".ak-slider-1")) {
      var swiper = new Swiper(".ak-slider-1", {
        loop: true,
        speed: 800,
        autoplay: false,
        slidesPerView: "auto",
        pagination: {
          el: ".ak-pagination",
          clickable: true,
        },
        navigation: {
          nextEl: ".ak-swiper-button-prev",
          prevEl: ".ak-swiper-button-next",
        },
      });
    }
    if ($.exists(".ak-slider-hero-2")) {
      var swiper = new Swiper(".ak-slider-hero-2", {
        loop: true,
        speed: 800,
        autoplay: false,
        slidesPerView: "auto",
        pagination: {
          el: ".ak-pagination",
          clickable: true,
        },
        navigation: {
          nextEl: ".ak-swiper-button-prev-hero-2",
          prevEl: ".ak-swiper-button-next-hero-2",
        },
      });
    }

    if ($.exists(".ak-slider-2")) {
      var swiper = new Swiper(".ak-slider-2", {
        loop: true,
        speed: 1000,
        autoplay: false,
        slidesPerView: "auto",
        spaceBetween: 30,
        pagination: {
          el: ".ak-pagination-2",
          clickable: true,
        },
        navigation: {
          nextEl: ".ak-swiper-button-prev-2",
          prevEl: ".ak-swiper-button-next-2",
        },
      });
    }
    if ($.exists(".ak-slider-3")) {
      var swiper = new Swiper(".ak-slider-3", {
        loop: true,
        speed: 1000,
        autoplay: false,
        slidesPerView: "auto",
        navigation: {
          nextEl: ".ak-swiper-button-prev-3",
          prevEl: ".ak-swiper-button-next-3",
        },
      });
    }
    if ($.exists(".ak-slider-4")) {
      var swiper = new Swiper(".ak-slider-4", {
        loop: true,
        speed: 1000,
        autoplay: true,
        slidesPerView: 1,
        navigation: {
          nextEl: ".ak-swiper-button-prev-4",
          prevEl: ".ak-swiper-button-next-4",
        },
      });
    }
    if ($.exists(".ak-slider-5")) {
      var swiper = new Swiper(".ak-slider-5", {
        loop: true,
        speed: 1000,
        autoplay: true,
        slidesPerView: 1,
        navigation: {
          nextEl: ".ak-swiper-button-prev-5",
          prevEl: ".ak-swiper-button-next-5",
        },
      });
    }
  }

  /*--------------------------------------------------------------
     6. Modal Video
 --------------------------------------------------------------*/
  function modalVideo() {
    $(document).on("click", ".ak-video-open", function (e) {
      e.preventDefault();
      var video = $(this).attr("href");
      video = video.split("?v=")[1].trim();
      $(".ak-video-popup-container iframe").attr(
        "src",
        `https://www.youtube.com/embed/${video}`
      );
      $(".ak-video-popup").addClass("active");
    });
    $(".ak-video-popup-close, .ak-video-popup-layer").on("click", function (e) {
      $(".ak-video-popup").removeClass("active");
      $("html").removeClass("overflow-hidden");
      $(".ak-video-popup-container iframe").attr("src", "about:blank");
      e.preventDefault();
    });
  }

  /*--------------------------------------------------------------
     7. Social Button Hover
--------------------------------------------------------------*/
  function hoverTab() {
    $(".ak-hover-tab").hover(function () {
      $(this).addClass("active").siblings().removeClass("active");
    });
  }

  /*--------------------------------------------------------------
     8. Light Gallery
--------------------------------------------------------------*/
  if ($.exists("#static-thumbnails")) {
    const galleryDiv = document.getElementById("static-thumbnails");
    lightGallery(galleryDiv, {
      selector: ".gallery-hover-icon a",
      addClass: "lg-custom-thumbnails",
      animateThumb: true,
      zoomFromOrigin: true,
      allowMediaOverlap: true,
      toggleThumb: true,
    });
  }

  /*--------------------------------------------------------------
     9. Comming soon
--------------------------------------------------------------*/

  if ($.exists("#commingsoon")) {
    commingSoon();

    function commingSoon() {
      const targetDate = new Date("2023-12-31T00:00:00").getTime();

      function updateCountdown() {
        const currentDate = new Date().getTime();
        const timeRemaining = targetDate - currentDate;

        if (timeRemaining <= 0) {
          document.getElementById("countdown").textContent =
            "The event is here!";
        } else {
          const months = Math.floor(
            timeRemaining / (1000 * 60 * 60 * 24 * 30.44)
          );
          const days = Math.floor(
            (timeRemaining % (1000 * 60 * 60 * 24 * 30.44)) /
              (1000 * 60 * 60 * 24)
          );
          const hours = Math.floor(
            (timeRemaining % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)
          );
          const minutes = Math.floor(
            (timeRemaining % (1000 * 60 * 60)) / (1000 * 60)
          );
          const seconds = Math.floor((timeRemaining % (1000 * 60)) / 1000);

          document.getElementById("months").textContent = `${months}`;
          document.getElementById("days").textContent = `${days}`;
          document.getElementById("hours").textContent = `${hours}`;
          document.getElementById("minutes").textContent = `${minutes}`;
          document.getElementById("secound").textContent = `${seconds}`;
        }
      }

      // Update the countdown every second (1000 milliseconds)
      setInterval(updateCountdown, 1000);

      // Initial call to set the countdown value
      updateCountdown();
    }
  }
  /*--------------------------------------------------------------
     10. Scroll Up
--------------------------------------------------------------*/
  function scrollUp() {
    $(".ak-scrollup").on("click", function (e) {
      e.preventDefault();
      $("html,body").animate(
        {
          scrollTop: 0,
        },
        0
      );
    });
  }
  // For Scroll Up
  function showScrollUp() {
    let scroll = $(window).scrollTop();
    if (scroll >= 350) {
      $(".ak-scrollup").addClass("ak-scrollup-show");
    } else {
      $(".ak-scrollup").removeClass("ak-scrollup-show");
    }
  }

  /*--------------------------------------------------------------
     11. Gsap Register Plugin
 --------------------------------------------------------------*/
  gsap.registerPlugin(ScrollTrigger, ScrollSmoother, ScrollToPlugin);
  gsap.config({
    nullTargetWarn: false,
  });
  const widthall = window.innerWidth;

  // create the smooth scroller FIRST!
  const smoother = ScrollSmoother.create({
    content: "#scrollsmoother-container",
    smooth: 1.2,
    normalizeScroll: true,
    ignoreMobileResize: true,
    effects: widthall > 991 ? true : false,
    smoothTouch: true,
  });

  /*--------------------------------------------------------------
     12. Heder Border Animations
 --------------------------------------------------------------*/

  if ($.exists(".nav-bar-border")) {
    let border = document.querySelectorAll(".nav-bar-border");
    gsap.fromTo(
      border,
      {
        duration: 1,
        width: "0%",
      },
      {
        delay: 1,
        duration: 1,
        width: "100%",
      }
    );
  }

  if ($.exists(".header-logo")) {
    let border = document.querySelectorAll(".header-logo");
    gsap.fromTo(
      border,
      {
        duration: 1,
        height: "0%",
      },
      {
        delay: 0.5,
        duration: 1,
        height: "100%",
      }
    );
  }

  if ($.exists(".ak-menu-toggle")) {
    let border = document.querySelectorAll(".ak-menu-toggle");
    gsap.fromTo(
      border,
      {
        duration: 1,
        height: "0%",
      },
      {
        duration: 1,
        height: "100%",
      }
    );
  }

  /*--------------------------------------------------------------
     13. Comming Soon and Error Pages Border Animations
 --------------------------------------------------------------*/
  if ($.exists(".border-comming-soon-top")) {
    let border = document.querySelectorAll(".border-comming-soon-top");
    gsap.fromTo(
      border,
      {
        duration: 1,
        width: "0%",
      },
      {
        delay: 1,
        duration: 1.5,
        width: "100%",
      }
    );
  }
  if ($.exists(".border-comming-soon-bottom")) {
    let border = document.querySelectorAll(".border-comming-soon-bottom");
    gsap.fromTo(
      border,
      {
        duration: 1,
        width: "0%",
      },
      {
        delay: 1,
        duration: 1,
        width: "100%",
      }
    );
  }
  if ($.exists(".border-comming-soon-colum-left")) {
    let border = document.querySelectorAll(".border-comming-soon-colum-left");
    gsap.fromTo(
      border,
      {
        duration: 1,
        height: "0%",
      },
      {
        delay: 2.2,
        duration: 1,
        height: "100%",
      }
    );
  }
  if ($.exists(".border-comming-soon-colum-right")) {
    let border = document.querySelectorAll(".border-comming-soon-colum-right");
    gsap.fromTo(
      border,
      {
        duration: 1,
        height: "0%",
      },
      {
        delay: 2.2,
        duration: 1,
        height: "100%",
      }
    );
  }

  /*--------------------------------------------------------------
      14. Top Header Slider Bar
 --------------------------------------------------------------*/
  if ($.exists(".ak-site_header .top-main-menu-li")) {
    let akMenuToggle = document.getElementById("akMenuToggle");
    const hamsdf = document.querySelector(".ak-main_header_right");
    const menu = document.querySelector(".top-main-menu");
    const links = menu.querySelectorAll(".top-main-menu-li");

    const menuItemBar = gsap.timeline();
    var navtl = gsap.timeline({ paused: true });
    navtl.set(hamsdf, {
      display: "none",
      transition: "all 0.5s ease-in",
    });

    menuItemBar.to(
      ".bar-1",
      0.5,
      {
        attr: { d: "M20,0 L2,9" },
        x: 1,
        ease: Power2.easeInOut,
      },
      "start"
    );

    menuItemBar.to(
      ".bar-2",
      0.5,
      {
        autoAlpha: 0,
      },
      "start"
    );
    menuItemBar.to(
      ".bar-3",
      0.5,
      {
        attr: { d: "M22,12 L2,0" },
        x: 1,
        ease: Power2.easeInOut,
      },
      "start"
    );

    navtl
      .to(menu, {
        duration: 0.3,
        opacity: 1,
        height: "116vh",
        ease: Expo.easeInOut,
        stagger: 0.1,
        background: "#040D10",
      })
      .fromTo(
        links,
        {
          duration: 0.3,
          opacity: 0,
          y: 30,
          ease: Expo.easeInOut,
        },
        {
          duration: 0.3,
          opacity: 1,
          y: -20,
          stagger: 0.1,
          ease: Expo.easeInOut,
        }
      );

    navtl.reverse();
    menuItemBar.reverse();
    gsap.set(links, {
      display: "none",
    });

    akMenuToggle.addEventListener("click", () => {
      if (!navtl.reversed()) {
        gsap.set(links, {
          padding: "0%",
          display: "none",
          paddingLeft: "0%",
          paddingRight: "0%",
        });
      } else {
        gsap.set(links, {
          display: "flex",
          paddingLeft: "15%",
          paddingRight: "5%",
        });
      }
      navtl.reversed(!navtl.reversed());
      menuItemBar.reversed(!menuItemBar.reversed());
    });
  }

  /*--------------------------------------------------------------
     15. Images Overlap
 --------------------------------------------------------------*/
  if ($.exists(".overlap-opening-img")) {
    let blogAnim = gsap.utils.toArray(".overlap-opening-img");
    const tl3 = gsap.timeline({
      scrollTrigger: {
        trigger: ".overlap-opening-img",
        start: "top 60%",
        end: "bottom 10%",
        scrub: false,
        markers: false,
      },
    });

    tl3.to(blogAnim, {
      ease: Expo.easeInOut,
      height: "0%",
      duration: 1,
      stagger: 2,
    });
  }

  if ($.exists(".img-overlay")) {
    let img_overlay = document.querySelectorAll(".img-overlay");
    img_overlay.forEach((item) => {
      const tl4 = gsap.timeline({
        scrollTrigger: {
          trigger: item,
          start: "top 60%",
          end: "bottom 10%",
          scrub: false,
          markers: false,
        },
      });
      tl4.to(item, {
        ease: Expo.easeInOut,
        height: "0%",
        duration: 1,
        stagger: 2,
      });
    });
  }

  /*--------------------------------------------------------------
    16. About Section Border Animations
 --------------------------------------------------------------*/
  if ($.exists(".ak-about-hr")) {
    const tl5 = gsap.timeline({
      scrollTrigger: {
        trigger: ".ak-about-hr",
        start: "top 90%",
        end: "bottom 10%",
        scrub: 0.5,
        markers: false,
      },
    });

    tl5.fromTo(
      ".ak-about-hr",
      {
        width: "2%",
      },
      {
        width: "13%",
      }
    );
  }

  /*--------------------------------------------------------------
    17. Portfolio Details Animations
 --------------------------------------------------------------*/
  if ($.exists(".ak-portfolio-details-border")) {
    const tl5 = gsap.timeline({
      scrollTrigger: {
        trigger: ".ak-portfolio-details-border",
        start: "top 90%",
        end: "bottom 10%",
        scrub: 0.5,
        markers: false,
      },
    });

    tl5.fromTo(
      ".ak-portfolio-details-border",
      {
        width: "5px",
      },
      {
        width: "250px",
      }
    );
  }
  /*--------------------------------------------------------------
    18. Food Menu Animations
 --------------------------------------------------------------*/
  if ($.exists(".food-menu-hr")) {
    let food_menu_hr = document.querySelectorAll(".food-menu-hr.style-1");
    const tl6 = gsap.timeline({
      scrollTrigger: {
        trigger: food_menu_hr,
        start: "top 90%",
        end: "bottom 10%",
        scrub: 0.5,
        markers: false,
      },
    });
    tl6.fromTo(
      food_menu_hr,
      {
        width: "0px",
      },
      {
        duration: 2,
        width: "200px",
      }
    );

    let ak_menu_list_anim_2 = document.querySelectorAll(
      ".food-menu-hr.style-1.anim-2"
    );
    const tl9 = gsap.timeline({
      scrollTrigger: {
        trigger: ak_menu_list_anim_2,
        start: "top 90%",
        end: "bottom 10%",
        scrub: 0.5,
        markers: false,
      },
    });
    tl9.fromTo(
      ak_menu_list_anim_2,
      {
        width: "0px",
      },
      {
        duration: 2,
        width: "200px",
      }
    );

    let ak_menu_list_anim_3 = document.querySelectorAll(
      ".food-menu-hr.style-1.anim-3"
    );
    const tl10 = gsap.timeline({
      scrollTrigger: {
        trigger: ak_menu_list_anim_3,
        start: "top 90%",
        end: "bottom 10%",
        scrub: 0.5,
        markers: false,
      },
    });
    tl10.fromTo(
      ak_menu_list_anim_3,
      {
        width: "0px",
      },
      {
        duration: 2,
        width: "200px",
      }
    );
  }
  /*--------------------------------------------------------------
    19. Footer Animations
 --------------------------------------------------------------*/
  if ($.exists(".ak-hr-container")) {
    const tl7 = gsap.timeline({
      scrollTrigger: {
        trigger: ".ak-hr-container",
        start: "top 90%",
        end: "bottom 10%",
        scrub: false,
        markers: false,
      },
    });

    tl7.fromTo(
      ".ak-footer-hr-top",
      {
        width: "0%",
        duration: 0.5,
      },
      {
        delay: 0.3,
        duration: 0.5,
        width: "100%",
      }
    );
    tl7.fromTo(
      ".ak-footer-hr-bottom",
      {
        width: "0%",
      },
      {
        duration: 0.5,
        width: "100%",
      }
    );
    tl7.to(".footer-time-border", {
      width: "100%",
    });
  }

  /*--------------------------------------------------------------
    20. loaction Section border Animitions 
 --------------------------------------------------------------*/
  if ($.exists(".ak-loaction-hr")) {
    const tl11 = gsap.timeline({
      scrollTrigger: {
        trigger: ".ak-loaction-hr",
        start: "top center+=200",
        end: "bottom 10%",
        scrub: false,
        markers: false,
      },
    });

    tl11.fromTo(
      ".ak-loaction-hr",
      {
        width: "0%",
      },
      {
        delay: 0.3,
        duration: 0.8,
        width: "100%",
      }
    );
  }
  /*--------------------------------------------------------------
    21. Images Zoom In and Out Animitions
 --------------------------------------------------------------*/
  if ($.exists(".imagesZoom")) {
    let imagesZoomAll = gsap.utils.toArray(".imagesZoom");
    imagesZoomAll.forEach((image) => {
      let tl12 = gsap.timeline({
        scrollTrigger: {
          trigger: image,
          start: "top 80%",
          end: "bottom 10%",
          scrub: 1,
          markers: false,
        },
      });

      tl12.fromTo(
        image,
        { scale: 1 },
        {
          scale: 1.15,
          duration: 3.5,
          ease: "expoScale(1, 1.15)",
          transformOrigin: "50% 50%",
          z: 0.1,
          rotationZ: "0.01",
        },
        "<"
      );
    });
  }

  /*--------------------------------------------------------------
    22. Title Animation
 --------------------------------------------------------------*/
  if ($.exists(".anim-title")) {
    let title_text = document.querySelectorAll(".anim-title");
    title_text.forEach((element) => {
      gsap.set(title_text, { overflow: "hidden" });
      const tlH = gsap.timeline({
        scrollTrigger: {
          trigger: element,
          start: "top 80%",
          end: "bottom 10%",
          scrub: false,
          markers: false,
        },
      });
      let textChars = new SplitText(element, {
        type: "chars words",
      });
      tlH.from(textChars.chars, {
        duration: 0.8,
        y: 200,
        autoAlpha: 0,
        scale: 0.1,
        stagger: {
          from: "start",
          axis: "x",
          amount: 0.3,
          ease: Quint.easeOut,
        },
      });
    });
  }

  if ($.exists(".anim-title-2")) {
    let animTitle2 = gsap.utils.toArray(".anim-title-2");
    animTitle2.forEach((element) => {
      let animTitleChar = new SplitText(element, {
        type: "chars ,words",
      });

      let tlH2 = gsap.timeline({
        scrollTrigger: {
          trigger: element,
          start: "top 80%",
          end: "bottom 10%",
          scrub: false,
          markers: false,
        },
      });

      tlH2.from(animTitleChar.chars, {
        duration: 0.8,
        scale: 1,
        y: 80,
        opacity: 0,
        rotationX: 100,
        transformOrigin: "0% 30% -30",
        ease: Expo.easeInOut,
        stagger: 0.05,
      });
    });
  }

  if ($.exists(".page-title-anim")) {
    gsap.from(".page-title-anim", 1, {
      y: 100,
      ease: "power4.out",
      delay: 0.8,
      stagger: {
        amount: 0.3,
      },
    });
  }
  if ($.exists(".anim-title-3")) {
    let title_text_3 = document.querySelectorAll(".anim-title-3");
    title_text_3.forEach((element) => {
      let title_text_3_Chars = new SplitText(element, {
        type: "chars words",
      });
      gsap.from(title_text_3_Chars.chars, {
        duration: 0.8,
        scale: 1,
        delay: 1,
        y: 80,
        opacity: 0,
        rotationX: 100,
        transformOrigin: "0% 30% -30",
        ease: Expo.easeInOut,
        stagger: 0.05,
      });
    });
  }

  /*--------------------------------------------------------------
    23. Hover Show Images
 --------------------------------------------------------------*/
  if ($.exists(".ak-menu-list-section-1")) {
    document
      .querySelectorAll(".ak-menu-list-section-1")
      .forEach(function (elem) {
        elem.addEventListener("mouseleave", function (dets) {
          gsap.to(elem.querySelector("img"), {
            opacity: 0,
            ease: Power3,
            duration: 0.8,
          });
        });

        elem.addEventListener("mousemove", function (dets) {
          var diff = dets.clientY - elem.getBoundingClientRect().top;
          var dilf = dets.clientX - elem.getBoundingClientRect().left;

          gsap.to(elem.querySelector("img"), {
            opacity: 1,
            ease: Power3,
            top: diff,
            left: dilf + 50,
          });
        });
      });
  }

  if ($.exists(".top-main-menu")) {
    document.querySelectorAll(".top-main-menu-li").forEach(function (elem) {
      elem.firstElementChild.addEventListener("mouseleave", function (dets) {
        console.log(elem.thirdElementChild);
        gsap.to(elem.querySelector("img"), {
          opacity: 0,
          ease: Power3,
          duration: 0.4,
          display: "none",
          width: "0%",
        });
      });

      elem.firstElementChild.addEventListener("mousemove", function (dets) {
        var diff = dets.clientY - elem.getBoundingClientRect().top;
        var dilf = dets.clientX - elem.getBoundingClientRect().left;
        gsap.to(elem.querySelector("img"), {
          opacity: 1,
          ease: Power3,
          duration: 0.4,
          display: "Block",
          width: "25%",
          top: diff,
          left: dilf - 500,
        });
      });
    });
  }

  /*--------------------------------------------------------------
    24. Scroll Down To Top Animation
 --------------------------------------------------------------*/
  if ($.exists(".loading-overlap")) {
    const elem = document.querySelector(".loading-overlap");
    const elem2 = document.querySelector(".footer-log-elem");
    var loadingElem = gsap.timeline();
    elem2.addEventListener("click", function () {
      loadingElem.to(elem, {
        duration: 0.3,
        height: "100vh",
        ease: Expo.easeInOut,
      });
      loadingElem.to("html,body", {
        scrollTop: 0,
      });
      loadingElem.to(elem, {
        delay: 0.1,
        top: 0,
        height: "0vh",
        duration: 0.4,
        ease: Expo.easeInOut,
      });
      loadingElem.to(elem, {
        buttom: 0,
      });
    });
  }
  /*--------------------------------------------------------------
    25. Scroll Effect Blog Details Page
 --------------------------------------------------------------*/
  if ($.exists("#infoProduto")) {
    if (widthall > 992) {
      let pinpontsection = document.getElementById("infoProduto");
      let galeria = document.getElementById("scrollGaleria");
      let section = document.getElementById("containerAround");

      ScrollTrigger.create({
        trigger: section,
        pin: pinpontsection,
        start: "top top",
        endTrigger: galeria,
        end: "bottom bottom",
      });
    }
  }

  /*--------------------------------------------------------------
    25. Scroll Effect Blog Details Page
 --------------------------------------------------------------*/

  if ($.exists("#foodItems")) {
    const scrollButton = document.getElementById("scroll-btn");
    const foodItems = document.querySelector("#foodItems");
    scrollButton.addEventListener("click", () => {
      gsap.to(window, {
        scrollTo: foodItems,
        duration: 0.3,
      });
    });
  }
  //end the scripts
})(jQuery);
