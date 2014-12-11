'use strict';

angular.module('choiceCeniumApp').controller('MainCtrl', function ($scope, $rootScope, signalRSvc, $timeout) {
	
	signalRSvc.initialize();

	//var animationLength = 7000;

	// Map init
	var map = L.mapbox.map('map', 'choicehotels.ich013bb')
		.setView([61.69, 5.999], 5);

	// Data
	$scope.hotelGeoJson = [];
    // TODO : Endre ved å sette .hotels direkte i populateHotels
	//$scope.hotels = getHotels();

	

	$rootScope.populateHotels = function(hotelInfo) {
	    $scope.KjedeUpdateStatus = hotelInfo.KjedeListUpgradeStatusSignalR;

	    $scope.KjedeUpdateStatus.each(function (kus) {
	        kus.statusArray = [];
            for (i = 0; i < kus.totalhotels; i++) {
                kus.statusArray[i] = i < kus.upgradedhotels;
	        }
	    });


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

	        if (hotelToCheck.ceniumversion > 5) {
	            dotImageElement.attr("src", "../images/dot-yellow.png");
	        }

	        if (hotelToCheck.notupgrading == 'true') {
	            dotImageElement.attr("src", "../images/dot-red.png");
	        }

	        if (hotelToCheck.upgradecomplete == 'true') {
	            dotImageElement.attr("src", "../images/dot-blue.png");
	        }

	        var upgradeDate = hotelToCheck.upgradedate.toString();

            if (upgradeDate.length > 5){

                if (isToday(upgradeDate)) {
                    dotImageElement.attr("src", "../images/dot-orange.png");
                    dotImageElement.addClass("dot-pulse");

                }

                //var upgradeMoment = moment(hotelToCheck.upgradedate);
	            //if(upgradeMoment.isValid()) {

	                

	                //var isMatch = moment().isSame(hotelToCheck.upgradedate, 'day');

	                //if (isMatch) {
	                //    alert("Datematch!");
	                //}

	                //console.log(hotelToCheck.hotelname + " >> " + upgradeMoment);
	            //}
            }
	    });
	};

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


// Animation
    //$scope.animate = function(booking) {

    //	if (booking) {

    //		var latlng = L.latLng(booking.to.lat, booking.to.lon);
    //		var latlngFrom = L.latLng(booking.from.lat, booking.from.lon);

    //		var notTheSameCoordinates = booking.to.lat != booking.from.lat && booking.to.lon != booking.from.lon;

    //		var bedString = "";
    //		for (var i = 0; i < booking.beds; i++) {
    //			bedString += "<img src='images/bed.png' class='bed'>";
    //		}

    //		var popup = L.popup({
    //			keepInView: false,
    //			autoPan: false,
    //			closeButton: false,
    //			zoomAnimation: false
    //		})
    //		.setLatLng(latlng);

    //		var brand = "";
    //		if (booking.title.toLowerCase().indexOf("clarion") >= 0) {
    //			brand = "clarion";
    //			popup.setContent(populatePopupContent(true, brand, booking.title, booking.description));
    //		} else if (booking.title.toLowerCase().indexOf("comfort") >= 0) {
    //			brand = "comfort";
    //			popup.setContent(populatePopupContent(true, brand, booking.title, booking.description));
    //		} else if (booking.title.toLowerCase().indexOf("quality") >= 0) {
    //			brand = "quality";
    //			popup.setContent(populatePopupContent(true, brand, booking.title, booking.description));
    //		} else {
    //			brand = "none";
    //			popup.setContent(populatePopupContent(false, brand, booking.title, booking.description));
    //		}

    //		var markerFrom = L.marker(latlngFrom, {
    //			icon: L.icon({
    //				iconUrl: 'images/dot-pulse.png',
    //				iconSize: [15, 15],
    //				"iconAnchor": [7, 7],
    //				className: "dot-pulse"
    //			})
    //		}).addTo(map);

    //		var markerTo = L.mapbox.featureLayer({
    //		    type: 'Feature',
    //		    zIndexOffset: 1000,
    //		    geometry: {
    //		        type: 'Point',
    //		        coordinates: [booking.to.lon, booking.to.lat]
    //		    },
    //		    properties: {
    //		        title: booking.title,
    //		        description: booking.description,
    //		        'marker-size': 'large',
    //		        'marker-color': '#444'
    //		    }
    //		});

    //		markerTo.bindPopup(popup);

    //		if (notTheSameCoordinates) {
    //			var t = setTimeout(function() {
    //				markerTo.addTo(map);
    //				markerTo.addLayer(popup);
    //			}, animationLength + 100);
    //		} else {
    //			var t = setTimeout(function() {
    //				markerTo.addTo(map);
    //				markerTo.addLayer(popup);
    //			}, 3000);
    //		}

    //		if (notTheSameCoordinates) {
    //			var start = { x: booking.from.lon, y: booking.from.lat };
    //			var end = { x: booking.to.lon, y: booking.to.lat };
    //			var generator = new arc.GreatCircle(start, end, { });
    //			var line = generator.Arc(100, { offset: 10 });

    //			L.geoJson(line.json()).addTo(map);

    //			var lineElement = $(".leaflet-zoom-animated g:last-child() path");
    //			var pathLength = document.querySelector(".leaflet-zoom-animated g:last-child path").getTotalLength();
    //			var lineColor = "#fa654b";

    //			lineElement.css({
    //				"stroke-dasharray" : pathLength,
    //				"stroke-dashoffset" : pathLength,
    //				"stroke": lineColor
    //			});
    //		}

    //		var pulsedot = $(".dot-pulse").last();

    //		var t = setTimeout(function() {
    //			pulsedot.animate({ "opacity": 0 }, 1000, function() {
    //				map.removeLayer(markerFrom);
    //			});

    //			if (notTheSameCoordinates) {
    //				lineElement.animate({ "opacity": 0 }, 1000, function() {
    //					lineElement.remove();
    //				});
    //			}
    //		}, animationLength + 2000);

    //		if (notTheSameCoordinates) {
    //			var t = setTimeout(function() {
    //				pulsedot.animate({ "opacity": 0 }, 1000, function() {
    //					map.removeLayer(markerFrom);
    //				});

    //				if (notTheSameCoordinates) {
    //					lineElement.animate({ "opacity": 0 }, 1000, function() {
    //						lineElement.remove();
    //					});
    //				}
    //			}, animationLength + 2000);

    //			var to = setTimeout(function() {
    //				map.removeLayer(markerTo);
    //			}, animationLength + 4000);
    //		} else {
    //			var t = setTimeout(function() {
    //				pulsedot.animate({ "opacity": 0 }, 1000, function() {
    //					map.removeLayer(markerFrom);
    //				});
    //				map.removeLayer(markerTo);
    //			}, animationLength);
    //		}

    //	}

    //}

});

//function populatePopupContent(hasImage, brand, title, description) {
//	if (hasImage) {
//		return "<div class='brand " + brand + "'></div>" + 
//		"<h2>" + title + " </h2>" + 
//		"<p> " + description + "</p>";
//	} else {
//		return "<h2>" + title + " </h2>" + 
//		"<p> " + description + "</p>";
//	}
//}

