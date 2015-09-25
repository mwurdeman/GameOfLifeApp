/**
 * Created by mwurd_000 on 8/31/2015.
 */
'use strict';

var gameOfLifeApp = angular.module('gameOfLifeApp', [
    'ngRoute',
    'gameOfLifeControllers'
]);

gameOfLifeApp.config(['$routeProvider',
    function($routeProvider) {
        $routeProvider.
            when('/DayOfWeek', {
                templateUrl: 'partials/dayoftheweek.html',
                controller: 'dayOfWeekController'
            }).
            otherwise({
                redirectTo: '/DayOfWeek'
            });
    }
]);