var citytour = {
    map: {
        googleMap: null,
        markers: [],
        lines: [],
        currentLocation: null,

        clearMap: function () {
            for (var i = 0; i < this.markers.length; i++) {
                this.markers[i].setMap(null);
            }
            this.markers.length = 0;

            for (var i = 0; i < this.lines.length; i++) {
                this.lines[i].setMap(null);
            }
            this.lines.length = 0;
        },

        setMarkers: function (locations, currentLocation) {
            var self = this;
            if (self.googleMap) {
                self.clearMap();

                var image = new google.maps.MarkerImage('content/images/person.png',
                            new google.maps.Size(40, 40), // This size of the marker.
                            new google.maps.Point(0, 0), // The origin for this image.
                            new google.maps.Point(20, 30) // The anchor for this image.
                        );

                if (currentLocation) {
                    var youAreHereMarker = new google.maps.Marker({
                        position: new google.maps.LatLng(currentLocation.lat, currentLocation.long),
                        map: self.googleMap,
                        icon: image,
                        title: 'You are here',
                        zIndex: 1
                    });
                    self.markers.push(youAreHereMarker);
                }

                $.each(locations, function (i, location) {
                    var marker = new google.maps.Marker({
                        position: new google.maps.LatLng(location.lat, location.long),
                        map: self.googleMap,
                        title: location.name,
                        zIndex: location.ranking
                    });
                    self.markers.push(marker);
                });
            }
        },

        joinLocations: function (locations, currentLocation) {
            if (this.googleMap) {
                var lineCordinates = [];
                $.each(this.markers, function (i, marker) {
                    lineCordinates.push(new google.maps.LatLng(marker.position.lat(), marker.position.lng()));
                });
                var line = new google.maps.Polyline({
                    path: lineCordinates,
                    strokeColor: "#FF0000",
                    strokeOpacity: 1.0,
                    strokeWeight: 2
                });

                line.setMap(this.googleMap);
                this.lines.push(line);
            }
        },

        render: function (elementId) {
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

                        self.currentLocation = {
                            lat: position.coords.latitude,
                            long: position.coords.longitude
                        }

                        google.maps.event.addListenerOnce(self.googleMap, 'idle', function () {
                            $(window).trigger('mapLoaded');
                        });
                    });
                }
            }
        },

        setLocations: function (locations) {
            this.setMarkers(locations, this.currentLocation);
            this.joinLocations(locations, this.currentLocation);
        },

        resize: function () {
            if (this.googleMap) {
                google.maps.event.trigger(this.googleMap, 'resize');
            }
        }
    }
}