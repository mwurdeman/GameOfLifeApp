/**
 * Created by mwurd_000 on 9/10/2015.
 */
'use strict';

var webApiAddress = 'http://gameoflifeapi.azurewebsites.net/';
var gameOfLifeServices = angular.module('gameOfLifeServices', ['ngResource']);

gameOfLifeServices.factory('StoreLocationService', ['$resource',
    function($resource) {
        return $resource(webApiAddress + 'api/StoreLocation/:id', {}, {
            all: {method: 'Get', params:{}, isArray: true},
            query: {method: 'Get', params:{id:'id'}, isArray: true},
            queryDay: {method: 'Get', params:{id:'dayOfWeek'}, isArray: true}
        });
    }
]);