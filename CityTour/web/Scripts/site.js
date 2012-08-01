jQuery(function ($) {
    // BUTTONS --------------------------------------------------------------------------------------------------------------- //
    $('button').button();

    // TABS ------------------------------------------------------------------------------------------------------------------ //
    $('#homeTabs').tabs({ selected: 5 });
    $('#homeTabs').bind('tabsselect', function (event, ui) {
        var currentMapContainer = $(ui.panel).find('.map');
        if (currentMapContainer.length > 0) {
            $('#citytourMap').appendTo(currentMapContainer);
        }

        switch (ui.index) {
            case 0:
                $(window).trigger('nearLocations');
                break;

            case 2:
                $(window).trigger('itinerary');
                break;
        }


    });
    $('#homeTabs').bind('tabsshow', function (event, ui) {
        if (citytour && citytour.map) {
            citytour.map.resize();
        }
    });

    $(window).bind('nearLocations', function () {
        if (citytour && citytour.map) {
            getNearLocations(citytour.map.currentLocation);
        }
    })

    $(window).bind('mapLoaded', function () {
        if (citytour && citytour.map) {
            getNearLocations(citytour.map.currentLocation);
        }
    })

    function getNearLocations(currentLocation) {
        $.ajax({
            url: './Home/GetNearLocations',            
            data: { latitude: currentLocation.lat, longitude: currentLocation.long },            
            success: function (locations) {
                citytour.map.setLocations(locations, false);
            }
        });
    }

});