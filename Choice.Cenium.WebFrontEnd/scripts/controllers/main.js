'use strict';

//$(document).ready ( function() {
//    initiateMapAndData();
//});

//function initiateMapAndData() {
    //$http.get('http://choicecenium.azurewebsites.net/api/WebJob');
//}

angular.module('choiceCeniumApp').controller('MainCtrl', function ($scope, $rootScope, signalRSvc, $timeout, $http) {
	


    signalRSvc.initialize();

    

	//var animationLength = 7000;

	// Map init
	var map = L.mapbox.map('map', 'choicehotels.ich013bb')
		.setView([61.69, 5.999], 5);

	// Data
	$scope.hotelGeoJson = [];

    // TODO : Endre ved å sette .hotels direkte i populateHotels
	//$scope.hotels = getHotels();
    function in3DaysRange(s, days) {
        var m = moment(s);

        if (m.isValid()) {

            var min = moment().subtract(days, 'days').startOf('day'),
                max = moment().add(days-1, 'days').endOf('day');

            return m.isAfter(min) && m.isBefore(max);
        }
    }

    function addHotelToNewsTicker(hotel) {
        var newsTicker = $('.marquee');

        //var dt = hotel.upgradedate.toString();

        var fDate = moment(hotel.upgradedate.toString()).format('LL');

        //var ugle = Date.Create(hotel.upgradedate).format('{dd}.{MM}.{yyyy}');
        //console.log(ugle);

        //var fDate = dt.substring(9, 2) + "." + dt.substring(6, 2) + dt.substring(0, 4); 

        newsTicker.append("<img src='../images/upgrade-icon.png' class='upgrade-icon'/>" + "&nbsp;" + hotel.hotelname + "&nbsp;&nbsp;:&nbsp;&nbsp;" + fDate + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
    }

    function getTransform(el) {
        var results = $(el).css('-webkit-transform').match(/matrix(?:(3d)\(\d+(?:, \d+)*(?:, (\d+))(?:, (\d+))(?:, (\d+)), \d+\)|\(\d+(?:, \d+)*(?:, (\d+))(?:, (\d+))\))/);

        if (!results) return [0, 0, 0];
        if (results[1] == '3d') return results.slice(2, 5);

        results.push(0);
        return results.slice(5, 8);
    }

    $rootScope.populateHotels = function(hotelInfo) {
	    $scope.KjedeUpdateStatus = hotelInfo.KjedeListUpgradeStatusSignalR;

	    $scope.KjedeUpdateStatus.each(function (kus) {
	        kus.statusArray = [];
            for (i = 0; i < kus.totalhotels; i++) {
                kus.statusArray[i] = i < kus.upgradedhotels;
	        }
	    });

        //reset the array so items don't stack after each call...
        $scope.hotelGeoJson = [];

	    for (var i = 0; i < hotelInfo.HotelListSignalR.length; i++) {
	        $scope.hotelGeoJson.push({
	            type: 'Feature',
	            "geometry": { "type": "Point", "coordinates": [hotelInfo.HotelListSignalR[i].lon, hotelInfo.HotelListSignalR[i].lat] },
	            "hotelinfo": {
	                "type": "Data",
	                "hotelname": [hotelInfo.HotelListSignalR[i].hotelname],
	                "ceniumversion": [hotelInfo.HotelListSignalR[i].currceniumversion],
	                "upgradedate": [hotelInfo.HotelListSignalR[i].upgradedate],
	                "notupgrading": [hotelInfo.HotelListSignalR[i].notupgrading],
	                "upgradecomplete": [hotelInfo.HotelListSignalR[i].ceniumupgradecomplete]
	            }
	        });
	    }

	    

	    map.markerLayer.setGeoJSON($scope.hotelGeoJson);

	    $("img.dot").each(function (index) {
	        var dotImageElement = $(this);
	        var hotelToCheck = $scope.hotelGeoJson[index].hotelinfo;

            // DESC > LAVERE ENN VERSJON 6
	        if (hotelToCheck.ceniumversion <= 5) {
	            dotImageElement.attr("src", "../images/dot-yellow.png");
	        }

	        // DESC > ER VERSJON 6
	        if (hotelToCheck.ceniumversion === 6) {
	            dotImageElement.attr("src", "../images/dot-orange.png");
	        }

	        // DESC > SKAL IKKE OPPGRADERES
	        if (hotelToCheck.notupgrading[0]) {
	            dotImageElement.attr("src", "../images/dot-red.png");
	        }

	        // DESC > FERDIG OPPGRADERT
	        if (hotelToCheck.upgradecomplete[0]) {
	            dotImageElement.attr("src", "../images/dot-blue.png");
	        }

	        var upgradeDate = hotelToCheck.upgradedate.toString();

            if (upgradeDate.length > 5){

                if (in3DaysRange(upgradeDate, 2)) {
                    dotImageElement.attr("src", "../images/dot-orange.png");
                    dotImageElement.addClass("dot-pulse");

                    addHotelToNewsTicker(hotelToCheck);
                } else {
                        dotImageElement.removeClass("dot-pulse");
                }
            }
	    });

        // clear div's...
	    $('.super-pulse').remove();

        $("img.dot-pulse").each(function() {
            var translate = getTransform($(this));

            $('.leaflet-marker-pane').append("<div class='super-pulse' style='transform: translate3d(" + translate[0] + "px, " + translate[1] + "px, "+ translate[2] + "px); z-index: 0;' />");

            //console.log(translate);
        });

	    initiateNewsTicker();

	};

    function initiateNewsTicker() {
	    $('.marquee').marquee({
	        //speed in milliseconds of the marquee
	        duration: 35000,
	        //gap in pixels between the tickers
	        gap: 50,
	        //time in milliseconds before the marquee will start animating
	        delayBeforeStart: 1000,
	        //'left' or 'right'
	        direction: 'left',
	        //true or false - should the marquee be duplicated to show an effect of continues flow
	        duplicated: false
	    });
    }

    function isToday(s) {
	    var m = moment(s);
	    if (m.isValid()) {
	        var isMatch = moment().isSame(m, 'day');
	        console.log((isMatch ? 'Is' : 'Is not') + ' match!');
	        return isMatch;
	    }
	}

    var timer;
    var fadeInBuffer = false;
    $(document).mousemove(function () {
        if (!fadeInBuffer) {
            if (timer) {
                clearTimeout(timer);
                timer = 0;
            }
            $('.fade-object').fadeIn();
            $('body').removeClass("no-cursor");
        } else {
            fadeInBuffer = false;
        }

        timer = setTimeout(function() {
            $('.fade-object').fadeOut();
            $('body').addClass("no-cursor");
            fadeInBuffer = true;
        }, 5000);
    });

	map.markerLayer.on('layeradd', function(e) {
	    var marker = e.layer,
	        feature = marker.feature;

	    marker.setIcon(L.icon({
	        "iconUrl": "images/dot.png",
	        "iconSize": [7, 7],
	        "iconAnchor": [3, 3],
	        "className": "dot"
	    }));
	});
	
});