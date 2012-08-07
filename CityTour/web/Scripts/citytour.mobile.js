var citytour = {
    location: {
        geoCoder: new google.maps.Geocoder(),
        detect: function (positionCallback, address) {
            var self = this;

            if (address) {
                self.geoCoder.geocode({ 'address': address }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        var location = results[0].geometry.location;
                        positionCallback({ lat: location.Xa, long: location.Ya });
                    }
                });
            }
            else if (Modernizr.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    positionCallback({ lat: position.coords.latitude, long: position.coords.longitude });
                });
            }
        },
        addressDetect: function (lat, long, addressCallback) {
            var self = this;
            var latlng = new google.maps.LatLng(lat, long);
            self.geoCoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    var result = "";
                    var street, number, neighbourhood, city, country;
                    if (results[0]) {
                        street = results[0].address_components[1].long_name;
                        number = results[0].address_components[0].long_name;
                        neighbourhood = results[0].address_components[2].long_name;
                        city = results[0].address_components[3].long_name;
                        country = results[0].address_components[5].long_name;

                        result = street + " " + number + ", " + neighbourhood + ", " + city + ", " + country;
                    }

                    addressCallback(result);
                }
            });
        }
    },
    map: {
        googleMap: null,
        currentLocation: null,
        setCurrentLocation: function () {
            var self = this;

            if (self.googleMap && self.currentLocation) {
                var image = new google.maps.MarkerImage('/content/images/person.png',
                            new google.maps.Size(40, 40), // This size of the marker.
                            new google.maps.Point(0, 0), // The origin for this image.
                            new google.maps.Point(20, 30) // The anchor for this image.
                        );
                var currentLocationMarker = new google.maps.Marker({
                    position: new google.maps.LatLng(self.currentLocation.lat, self.currentLocation.long),
                    map: self.googleMap,
                    icon: image
                });
            }
        },
        setMarkers: function (locations) {
            var self = this;

            if (self.googleMap && locations) {
                $.each(locations, function (i, location) {
                    var marker = new google.maps.Marker({
                        position: new google.maps.LatLng(location.lat, location.long),
                        map: self.googleMap,
                        title: location.name
                    });
                });
            }
        },
        render: function (mapElement, position, locations) {
            var self = this;

            self.currentLocation = position ? position : (locations ? locations[0] : null);

            if (self.currentLocation) {
                var options = {
                    zoom: 15,
                    center: new google.maps.LatLng(self.currentLocation.lat, self.currentLocation.long),
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                self.googleMap = new google.maps.Map(mapElement, options);

                if (position) {
                    self.setCurrentLocation();
                }
            }

            if (locations) {
                self.setMarkers(locations);
            }
        },
        renderDirections: function (map, position, locations) {
            var self = this;
            var startLocation = new google.maps.LatLng(position.lat, position.long);

            var lastIndex = locations.length - 1;
            var endLocation = new google.maps.LatLng(locations[lastIndex].lat, locations[lastIndex].long);
            var waypoints = [];

            $.each(locations, function (i, location) {
                if (i < lastIndex) {
                    waypoints.push({ location: new google.maps.LatLng(location.lat, location.long), stopover: true });
                }
            });

            var request = {
                origin: startLocation,
                destination: endLocation,
                waypoints: waypoints,
                optimizeWaypoints: false,
                travelMode: google.maps.DirectionsTravelMode.DRIVING
            };

            var directionsService = new google.maps.DirectionsService();
            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    var directionsDisplay = new google.maps.DirectionsRenderer();
                    directionsDisplay.setMap(self.googleMap);
                    directionsDisplay.setDirections(response);
                }
            });
        }
    }
}

$.ajaxSetup({ cache: false });
$.mobile.page.prototype.options.domCache = false;

$(document).bind("pagechange", function (a, b) {
    var activePage = $.mobile.activePage;
    var maps = $(".map-canvas", activePage);

    maps.each(function (i, map) {
        var $map = $(map);
        var mapData = $(map).data("map");

        if (mapData.commerceLocation) {
            citytour.map.render(map, null, [mapData.commerceLocation]);
        }
        else if (mapData.itinerary) {
            var $list = $("#" + mapData.itinerary.listId);
            var locations = $("a", $list).map(function (i, item) {
                return $(item).data("location");
            });

            citytour.location.detect(function (position) {
                citytour.map.render(map, position);
                citytour.map.renderDirections(map, position, locations);
            });
        }
        else if (mapData.nearLocations) {
            var $list = $("#" + mapData.nearLocations.listId, activePage).empty().hide();

            citytour.location.detect(function (position) {
                $.getJSON(mapData.nearLocations.url,
                    { latitude: position.lat, longitude: position.long },
                    function (data) {
                        if (data) {
                            citytour.map.render(map, position, data);
                            citytour.location.addressDetect(position.lat, position.long, function (address) {
                                $(".map-address").html(address);
                            });

                            if (data.length > 0) {
                                var $locations = $("<ul data-role=\"listview\" data-inset=\"true\"></ul>");
                                $.each(data, function (i, location) {
                                    $("<li><a href=\"" + location.url + "\">" + location.name + "</a></li>").appendTo($locations);
                                });

                                $list.html($locations);
                                $locations.listview();
                            }
                            else {
                                $list.html($("<p class=\"map-empty\">" + mapData.nearLocations.emptymsg + "</p>"));
                            }

                            $list.show();
                        }
                    });
            }, mapData.nearLocations.address);
        }
    });
});
