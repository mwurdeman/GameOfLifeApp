/**
 * Created by mwurd_000 on 9/4/2015.
 */
'use strict';

var gameOfLifeControllers = angular.module('gameOfLifeControllers', [
    'gameOfLifeServices'
]);

gameOfLifeControllers.controller('dayOfWeekController', ['$scope', 'StoreLocationService',
    function ($scope, StoreLocationService) {

        var now = new Date();
        var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
        var day = days[now.getDay()];

        $scope.DayOfWeek = day;
        $scope.Day = now.getDay();
        findStoreLocationDeals(day);

        function findStoreLocationDeals(dayOfWeek) {
            StoreLocationService.queryDay({id: dayOfWeek}, function (data) {
                $scope.StoreLocations = data;
                $scope.NoData = false;
                console.log($scope.Locations)
            }, function (error) {
                $scope.Error = "Yes there was an error";
                $scope.NoData = true;
                console.log($scope.Error);
            });
        }

        $scope.changeDay = function (moveDay) {
            $scope.Day = $scope.Day + moveDay;

            if ($scope.Day == 7) {
                $scope.Day = 0;
            }

            if ($scope.Day == -1) {
                $scope.Day = 6;
            }

            $scope.DayOfWeek = days[$scope.Day];
            findStoreLocationDeals($scope.DayOfWeek);
        };
    }
]);
