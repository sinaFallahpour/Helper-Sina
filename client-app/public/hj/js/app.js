// var swiper = new Swiper(".swiper-container1", {
//   effect: "coverflow",
//   grabCursor: true,
//   centeredSlides: true,
//   slidesPerView: "auto",
//   coverflowEffect: {
//     rotate: 50,
//     stretch: 0,
//     depth: 100,
//     modifier: 1,
//     slideShadows: true,
//   },
//   pagination: {
//     el: ".swiper-pagination",
//   },
// });

//-----timer number----
(function ($) {
  $.fn.countTo = function (options) {
    options = options || {};

    return $(this).each(function () {
      // set options for current element
      var settings = $.extend(
        {},
        $.fn.countTo.defaults,
        {
          from: $(this).data("from"),
          to: $(this).data("to"),
          speed: $(this).data("speed"),
          refreshInterval: $(this).data("refresh-interval"),
          decimals: $(this).data("decimals"),
        },
        options
      );

      // how many times to update the value, and how much to increment the value on each update
      var loops = Math.ceil(settings.speed / settings.refreshInterval),
        increment = (settings.to - settings.from) / loops;

      // references & variables that will change with each update
      var self = this,
        $self = $(this),
        loopCount = 0,
        value = settings.from,
        data = $self.data("countTo") || {};

      $self.data("countTo", data);

      // if an existing interval can be found, clear it first
      if (data.interval) {
        clearInterval(data.interval);
      }
      data.interval = setInterval(updateTimer, settings.refreshInterval);

      // initialize the element with the starting value
      render(value);

      function updateTimer() {
        value += increment;
        loopCount++;

        render(value);

        if (typeof settings.onUpdate == "function") {
          settings.onUpdate.call(self, value);
        }

        if (loopCount >= loops) {
          // remove the interval
          $self.removeData("countTo");
          clearInterval(data.interval);
          value = settings.to;

          if (typeof settings.onComplete == "function") {
            settings.onComplete.call(self, value);
          }
        }
      }

      function render(value) {
        var formattedValue = settings.formatter.call(self, value, settings);
        $self.html(formattedValue);
      }
    });
  };

  $.fn.countTo.defaults = {
    from: 0, // the number the element should start at
    to: 0, // the number the element should end at
    speed: 1000, // how long it should take to count between the target numbers
    refreshInterval: 100, // how often the element should be updated
    decimals: 0, // the number of decimal places to show
    formatter: formatter, // handler for formatting the value before rendering
    onUpdate: null, // callback method for every time the element is updated
    onComplete: null, // callback method for when the element finishes updating
  };

  function formatter(value, settings) {
    return value.toFixed(settings.decimals);
  }
})(jQuery);

jQuery(function ($) {
  // custom formatting example
  $(".count-number").data("countToOptions", {
    formatter: function (value, options) {
      return value
        .toFixed(options.decimals)
        .replace(/\B(?=(?:\d{3})+(?!\d))/g, ",");
    },
  });

  // start all the timers
  $(".timer").each(count);

  function count(options) {
    var $this = $(this);
    options = $.extend({}, options || {}, $this.data("countToOptions") || {});
    $this.countTo(options);
  }
});

//-----End timer number----
//--chatr---

//-----profile----
$(document).ready(function () {
  var valid = true;
  $("#plus-profile").on("click", function () {
    if (valid) {
      valid = false;
      $("#Record").toggleClass("toggle-Record");
      $("#plus-profile").addClass("fa-minus-circle");
      $("#plus-profile").removeClass("fa-plus-circle");
    } else {
      valid = true;
      $("#Record").toggleClass("toggle-Record");
      $("#plus-profile").removeClass("fa-minus-circle");
      $("#plus-profile").addClass("fa-plus-circle");
    }
  });
});

////----chart----
//$(function() {
//  var chart1Selected,
//      chart2Selected;

//  // create the chart
//  var chart = new Highcharts.Chart({
//    chart: {
//      renderTo: 'chart1',
//      events: {
//        selection: function(event) {
//          var xMin = chart.xAxis[0].translate((event.xAxis[0] || chart.xAxis[0]).min),
//            xMax = chart.xAxis[0].translate((event.xAxis[0] || chart.xAxis[0]).max),
//            yMin = chart.yAxis[0].translate((event.yAxis[0] || chart.yAxis[0]).min),
//            yMax = chart.yAxis[0].translate((event.yAxis[0] || chart.yAxis[0]).max);

//          chart1Selected.attr({
//            x: xMin + chart.plotLeft,
//            y: chart.plotHeight + chart.plotTop - yMax,
//            width: xMax - xMin,
//            height: yMax - yMin
//          });
//          chart2Selected.attr({
//            x: xMin + chart.plotLeft,
//            y: chart.plotHeight + chart.plotTop - yMax,
//            width: xMax - xMin,
//            height: yMax - yMin
//          });

//          return false;
//        }
//      },
//      zoomType: 'xy'
//    },
//    title: {
//      text: 'Chart 1'
//    },
//    xAxis: {},

//    series: [{
//      data: [29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4]
//    }]
//  });

//  // Draw the area in the charts
//  chart1Selected = chart.renderer.rect(0, 0, 0, 0, 0).css({
//    stroke: 'red',
//    strokeWidth: '.5',
//    fill: 'red',
//    fillOpacity: '.1'
//  }).add();
//  chart2Selected = chart1.renderer.rect(0, 0, 0, 0, 0).css({
//    stroke: 'red',
//    strokeWidth: '.5',
//    fill: 'red',
//    fillOpacity: '.1'
//  }).add();
//});

//.............

//----like----
function myFunction(x) {
  x.classList.toggle("fas");
}

//---end like----

//----swiper---
var swiper = new Swiper(".swiper-container2", {
  slidesPerView: 3,
  spaceBetween: 30,
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
  breakpoints: {
    // when window width is <= 499px
    0: {
      slidesPerView: 1,
      spaceBetweenSlides: 30,
    },
    // when window width is <= 999px
    999: {
      slidesPerView: 3,
      spaceBetweenSlides: 40,
    },
  },
});

//----- swiper3-----
var swiper = new Swiper(".swiper-container3", {
  slidesPerView: 4,
  spaceBetween: 30,
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
  breakpoints: {
    // when window width is <= 499px
    0: {
      slidesPerView: 1,
      spaceBetweenSlides: 30,
    },
    // when window width is <= 999px
    999: {
      slidesPerView: 4,
      spaceBetweenSlides: 40,
    },
  },
});

//select down

$("#select-down").on("click", function () {
  $(".hj-select").toggleClass("hj-select-block");
  $("#select-down").toggleClass("fa-chevron-up");
});

//----
$("#Pricerange-down").on("click", function () {
  $(".hj-cost-service").toggleClass("hj-cost-service-block");
  $("#Pricerange-down").toggleClass("fa-chevron-up");
});

//-----loader----
// Preloader JS
// $(window).on('load', function () {
//     $(".loader").fadeOut(500);
// });

//---endloader-------

//-----show password----

//---pas1--
// function showpass1() {
//   var x = document.getElementById("password1");
//   if (x.type === "password") {
//     x.type = "text";
//   } else {
//     x.type = "password";
//   }
// }

//- pass 2---

// function showpass2() {
//   var x = document.getElementById("password2");
//   if (x.type === "password") {
//     x.type = "text";
//   } else {
//     x.type = "password";
//   }
// }

//- pass 2---
// function showpass3() {
//   var x = document.getElementById("password3");
//   if (x.type === "password") {
//     x.type = "text";
//   } else {
//     x.type = "password";
//   }
// }

//----end show passw0rd--
