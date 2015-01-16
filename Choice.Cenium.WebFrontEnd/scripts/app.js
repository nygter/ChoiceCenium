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

app.factory('signalRSvc', function ($, $rootScope, $http) {
  return {
    proxy: null,
    initialize: function () {

        $.connection.hub.url = "http://choicecenium.azurewebsites.net/signalr/hubs";

        //$.connection.hub.url = "http://https://choicelive-be.choice.no/signalr/hubs/signalr/hubs";
        var flight = $.connection.hotelInfoHub;
      $.connection.hub.logging = true;

      flight.client.addNewMessageToPage = function(hotelInfo) {
        // console.log(booking);
          $rootScope.$apply(function () {
              console.log(hotelInfo);
              $rootScope.populateHotels(hotelInfo);
          });
      }

      

      //Getting the connection object
      $.connection.hub.start()
      .done(function () {

          $http.get('http://choicecenium.azurewebsites.net/api/WebJob');
          //// TODO: Initialize kode.. kall på initialize signalR
          //flight.client.addNewMessageToPage = function (hotelInfo) {
          //    // console.log(booking);
          //    $rootScope.$apply(function () {
          //        console.log(hotelInfo);
          //        $rootScope.populateHotels(hotelInfo);
          //    });
          //}


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
  