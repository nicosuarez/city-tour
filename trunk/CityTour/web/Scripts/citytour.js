var citytour = {
    map: {
        googleMap: null,

        setMarkers: function (locations, currentLocation) {
            var self = this;
            if (self.googleMap) {
                var image = new google.maps.MarkerImage('content/images/person.png',
                            new google.maps.Size(40, 40), // This size of the marker.
                            new google.maps.Point(0, 0), // The origin for this image.
                            new google.maps.Point(20, 30) // The anchor for this image.
                        );

                if (currentLocation)
                    var youAreHereMarker = new google.maps.Marker({
                        position: new google.maps.LatLng(currentLocation.lat, currentLocation.long),
                        map: self.googleMap,
                        icon: image,
                        title: 'You are here',
                        zIndex: 1
                    });

                $.each(locations, function (i, location) {
                    var marker = new google.maps.Marker({
                        position: new google.maps.LatLng(location.lat, location.long),
                        map: self.googleMap,
                        title: location.name,
                        zIndex: location.ranking
                    });
                });
            }
        },

        joinLocations: function (locations, currentLocation) {
            if (this.googleMap) {
                if (currentLocation) {
                    locations.push(currentLocation);
                }

                var lineCordinates = [];
                $.each(locations, function (i, location) {
                    lineCordinates.push(new google.maps.LatLng(location.lat, location.long));
                });
                var Line = new google.maps.Polyline({
                    path: lineCordinates,
                    strokeColor: "#FF0000",
                    strokeOpacity: 1.0,
                    strokeWeight: 2
                });
                Line.setMap(this.googleMap);
            }
        },

        render: function (elementId, locations) {
            var self = this;
            if (google.maps.Map) {
                if (Modernizr.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {
                        var options = {
                            zoom: 15,
                            center: new google.maps.LatLng(position.coords.latitude, position.coords.longitude),
                            mapTypeId: google.maps.MapTypeId.ROADMAP
                        };

                        self.googleMap = new google.maps.Map(document.getElementById(elementId), options);

                        var currentLocation = {
                            lat: position.coords.latitude,
                            long: position.coords.longitude
                        }

                        self.setMarkers(locations, currentLocation);
                        self.joinLocations(locations, currentLocation);
                    });
                }
            }
        },

        resize: function () {
            if (this.googleMap) {
                google.maps.event.trigger(this.googleMap, 'resize');
            }
        }
    }
}