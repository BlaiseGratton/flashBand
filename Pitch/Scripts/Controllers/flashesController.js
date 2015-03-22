'use strict';
angular.module('pitchApp')
    .controller('FlashesController', ['$scope', '$http', 'localStorageService', 'Songs', 'Instruments', function($scope, $http, localStorageService, Songs, Instruments){
        var vm = this;

        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.request.instrumentIDs = [];

        $scope.request.songIDs = [];

        $scope.getFlashes = function () {
            $http.get('api/Flashes/' + $scope.request)
                                .success(function (response) {
                                    $scope.flashes = response;
                                })
                                .error(function (err) {
                                    console.log(err.message);
                                });
        };

        $scope.allSongs = Songs.query();

        $scope.allInstruments = Instruments.query();

        $scope.addSongIdToRequest = function(songId){
            $scope.songIDs.push(songId);
        }

        $scope.addInstIdToRequest = function(instId){
            $scope.instrumentIDs.push(instId);
        }
    }])