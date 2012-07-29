var citytour = {
    location: {
        detect: function (positionCallback) {
            if (Modernizr.geolocation) {
                navigator.geolocation.getCurrentPosition(positionCallback);
            }
        }
    },
    map: {
        googleMap: null,
        currentLocation: null,
        setCurrentLocation: function () {
            var self = this;

            if (self.googleMap && self.currentLocation) {
                var image = new google.maps.MarkerImage('content/images/person.png',
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
        render: function (elementId, position, locations) {
            var self = this;

            if (position) {
                self.currentLocation = {
                    lat: position.coords.latitude,
                    long: position.coords.longitude
                }

                if (google.maps.Map) {
                    var options = {
                        zoom: 15,
                        center: new google.maps.LatLng(position.coords.latitude, position.coords.longitude),
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    };

                    self.googleMap = new google.maps.Map(document.getElementById(elementId), options);
                }

                self.setCurrentLocation();
                self.setMarkers(locations);
            }
        }
    }
}

function page_locations_map_init() {
    citytour.location.detect(function (position) {
        var $container = $("#near_locations_list");

        $.getJSON($container.data("apiurl"),
            { latitude: position.coords.latitude, longitude: position.coords.longitude },
            function (data) {
                if (data) {
                    citytour.map.render("map_locations", position, data);

                    var $nearLocations = $("<ul data-role=\"listview\" data-inset=\"true\"></ul>");
                    $.each(data, function (i, location) {
                        $("<li><a href=\"#\">" + location.name + "</a></li>").appendTo($nearLocations);
                    });

                    $container.html($nearLocations);
                    $nearLocations.listview();
                }
                else {
                    $container.html($("<p>" + $container.data("emptymsg") + "</p>"));
                }
            });
    });
}

$(document).bind("pagechange", function (a, b) {
    var activePage = $.mobile.activePage.data("url");
    var mapFunctionName = activePage + "_map_init";
    var mapFunction = window[mapFunctionName];

    if (mapFunction) {
        mapFunction();
    }
});