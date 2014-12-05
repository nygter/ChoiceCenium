'use strict';

var app = angular.module('choiceCeniumApp', ['ngCookies', 'ngResource', 'ngSanitize', 'ngRoute']);
//var app = angular.module('choiceCeniumApp', ['ngCookies', 'ngResource', 'ngSanitize', 'ngRoute', 'countTo']);

app.value('$', $);

app.config(function ($routeProvider) {
  $routeProvider
    .when('/', {
      templateUrl: 'views/main.html',
      controller: 'MainCtrl'
    })
    .otherwise({
      redirectTo: '/'
    });

});

app.factory('signalRSvc', function ($, $rootScope) {
  return {
    proxy: null,
    initialize: function () {

        $.connection.hub.url = "http://localhost:50535/signalr/hubs";
        //$.connection.hub.url = "http://https://choicelive-be.choice.no/signalr/hubs/signalr/hubs";
        var flight = $.connection.hotelInfoHub;
      $.connection.hub.logging = true;

      flight.client.addNewMessageToPage = function(hotelInfo) {
        // console.log(booking);
          $rootScope.$apply(function () {
              console.log(hotelInfo);
              // UGLE : TODO : TERJE  (ref. til main.js gjør stuff and stuff... and stuff.
              $rootScope.populateHotels(hotelInfo);
          });
      }

      //Getting the connection object
      $.connection.hub.start()
      .done(function () {
          console.log('Now connected, connection ID=' + $.connection.hub.id);
          $(".connection-spinner").css({ "display": "none" });

          // $.connection.hub.connectionSlow(function () {
          //     $(".connection-spinner").css({ "display": "block" });
          // });

          $.connection.hub.reconnected(function () {
              $(".connection-spinner").css({ "display": "none" });
          });
      })
      .fail(function () {
          $(".connection-spinner").css({ "display": "block" });
      });
      
    },
    sendRequest: function (callback) {
        console.log("Send request");
    }
  }
});
  