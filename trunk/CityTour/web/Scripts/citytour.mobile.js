var citytour = {
    location: {
        geoCoder: new google.maps.Geocoder(),
        detect: function (positionCallback, address) {
            var self = this;

            if (address) {
                self.geoCoder.geocode({ 'address': address }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        var location = results[0].geometry.location;
                        positionCallback({ lat: location.Ya, long: location.Za });
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

            if (position) {
                self.currentLocation = position;

                if (google.maps.Map) {
                    var options = {
                        zoom: 15,
                        center: new google.maps.LatLng(self.currentLocation.lat, self.currentLocation.long),
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    };

                    self.googleMap = new google.maps.Map(mapElement, options);
                }

                self.setCurrentLocation();
                self.setMarkers(locations);
            }
        }
    }
}

$(document).bind("pagechange", function (a, b) {
    var activePage = $.mobile.activePage;
    var maps = $(".map-canvas", activePage);

    maps.each(function (i, map) {
        var $map = $(map);
        var mapData = $(map).data("locations");
        var $list = $("#" + mapData.listId, activePage).empty().hide();

        citytour.location.detect(function (position) {
            $.getJSON(mapData.apiurl,
                { latitude: position.lat, longitude: position.long },
                function (data) {
                    if (data) {
                        citytour.map.render(map, position, data);
                        citytour.location.addressDetect(position.lat, position.long, function (address) {
                            $("<h4>" + address + "</h4>").insertBefore($map);
                        });

                        var $locations = $("<ul data-role=\"listview\" data-inset=\"true\"></ul>");
                        $.each(data, function (i, location) {
                            $("<li><a href=\"#\">" + location.name + "</a></li>").appendTo($locations);
                        });

                        $list.html($locations);
                        $locations.listview();
                    }
                    else {
                        $list.html($("<p>" + mapData.emptymsg + "</p>"));
                    }

                    $list.show();
                });
        }, mapData.address);
    });
});
