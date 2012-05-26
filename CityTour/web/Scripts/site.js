jQuery(function ($) {
    // BUTTONS --------------------------------------------------------------------------------------------------------------- //
    $('button').button();

    // TABS ------------------------------------------------------------------------------------------------------------------ //
    $('#homeTabs').tabs({ selected: 2 });

    // GEOLOCATION ----------------------------------------------------------------------------------------------------------- //
    var mapCanvas = $('#mapCanvas').first().get();

    if (google.maps.Map && mapCanvas) {
        if (Modernizr.geolocation) {
            var places = [
                    { name: 'Restaurant X', lat: -0.002, long: 0.002, ranking: 4 },
                    { name: 'Hotel Y', lat: -0.002, long: -0.002, ranking: 3 },
                    { name: 'Teatro Z', lat: 0.002, long: 0.002, ranking: 2 },
                    { name: 'Restaurant A', lat: 0.002, long: -0.002, ranking: 1 }
                ];

            function setMarkers(map, locations) {
                var image = new google.maps.MarkerImage('content/images/person.png',
                        new google.maps.Size(40, 40), // This size of the marker.
                        new google.maps.Point(0, 0), // The origin for this image.
                        new google.maps.Point(20, 30) // The anchor for this image.
                    );

                var youAreHereMarker = new google.maps.Marker({
                    position: new google.maps.LatLng(map.center.$a, map.center.ab),
                    map: map,
                    icon: image,
                    title: 'You are here',
                    zIndex: 1
                });

                $.each(locations, function (i, location) {
                    var marker = new google.maps.Marker({
                        position: new google.maps.LatLng(map.center.$a + location.lat, map.center.ab + location.long),
                        map: map,
                        title: location.name,
                        zIndex: location.ranking
                    });
                });
            }

            navigator.geolocation.getCurrentPosition(function (position) {
                var options = {
                    zoom: 15,
                    center: new google.maps.LatLng(position.coords.latitude, position.coords.longitude),
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                var map = new google.maps.Map(document.getElementById('mapCanvas'), options);
                setMarkers(map, places);
            });
        }
        else {
            // Identificación manual por dirección.
        }
    }
});