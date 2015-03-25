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
        $scope.$watchCollection('requestInstruments', function () {
            var reqInst = $scope.requestInstruments;
            if (reqInst.length === 1) {
                $scope.instrumentList = reqInst[0].name.toLowerCase() + " ";
            }
            if (reqInst.length === 2) {
                $scope.instrumentList = reqInst[0].name.toLowerCase() + " and " + reqInst[1].name.toLowerCase() + " ";
            }
            if (reqInst.length > 2) {
                var stringBuilder = "";
                var commaLength = reqInst.length - 2;
                for (var i = 0; i < commaLength; i++) {
                    stringBuilder += reqInst[i].name.toLowerCase() + ", ";
                }
                stringBuilder += reqInst[i].name.toLowerCase() + " and " + reqInst[i + 1].name.toLowerCase() + " ";
                $scope.instrumentList = stringBuilder;
            }

        });

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

        $scope.searchSongs = function () {
            if ($scope.searchString.length === 0) {
                $scope.searchSongResults = [];
            }
            if ($scope.searchString.length > 2) {
                $http.get('api/Search/Songs/' + $scope.searchString)
                    .success(function (data) {
                        $scope.searchSongResults = data;
                    })
                    .error(function (err) { });
            };
        };

        $scope.addSongToRequest = function(song){
            if ($scope.requestSongs.indexOf(song) === -1) {
                $scope.requestSongs.push(song);
            }
        };

        $scope.removeFromRequest = function(song){
            var index = $scope.requestSongs.indexOf(song);
            $scope.requestSongs.splice(index, 1);
        };
    }])