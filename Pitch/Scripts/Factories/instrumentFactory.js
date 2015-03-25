'use strict';
angular.module('pitchApp')
    .factory('instrumentFactory', ['Instruments', '$http', 'localStorageService', '$rootScope', function(Instruments, $http, localStorageService, $rootScope){
        var userId = localStorageService.get('authorizationData').userId;

        var instrumentFactory = {};

        instrumentFactory.userInstruments = [];

        $http.get("api/Users/" + userId + "/Instruments").then(
            function(data){
                instrumentFactory.userInstruments = data.data;
                $rootScope.$broadcast("valuesUpdated");
            }, function(err){
                console.log(err.message);
            }
        );

        instrumentFactory.updateInstruments = function(instruments){
            this.userInstruments = instruments;
            $rootScope.$broadcast("valuesUpdated");
        };

        return instrumentFactory;
    }])