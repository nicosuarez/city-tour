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
    });
    $('#homeTabs').bind('tabsshow', function (event, ui) {
        if (citytour && citytour.map) {
            citytour.map.resize();
        }
    });

    if (citytour && citytour.map) {
        var places = [
            { name: 'Restaurant X', lat: -0.002, long: 0.002, ranking: 4 },
            { name: 'Hotel Y', lat: -0.002, long: -0.002, ranking: 3 },
            { name: 'Teatro Z', lat: 0.002, long: 0.002, ranking: 2 },
            { name: 'Restaurant A', lat: 0.002, long: -0.002, ranking: 1 }
        ];

        citytour.map.setLocations(places);
    }

});