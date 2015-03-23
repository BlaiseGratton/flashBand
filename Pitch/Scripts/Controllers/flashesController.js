'use strict';
angular.module('pitchApp')
    .controller('FlashesController', ['$scope', '$http', 'localStorageService', 'Songs', 'Instruments', function($scope, $http, localStorageService, Songs, Instruments){
        var vm = this;

        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.request = {};
        $scope.requestInstruments = [];
        $scope.requestSongs = [];
        $scope.request.instrumentIDs = [];
        $scope.request.songIDs = [];

        $scope.getFlashes = function () {
            $scope.requestInstruments.forEach(function(instrument){
                $scope.request.instrumentIDs.push(instrument.id);
            });
            $scope.requestSongs.forEach(function(song){
                $scope.request.songIDs.push(song.id);
            });
            $http.post('api/Flashes/', $scope.request)
                                .success(function (response) {
                                    $scope.flashes = response;
                                    $scope.request.instrumentIDs = [];
                                    $scope.request.songIDs = [];
                                })
                                .error(function (err) {
                                    console.log(err.message);
                                });
        };

        $scope.allSongs = Songs.query();

        $scope.allInstruments = Instruments.query();
    }])