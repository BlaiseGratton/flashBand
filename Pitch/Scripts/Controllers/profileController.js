'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['localStorageService', 'Users', 'Instruments', 'Songs', '$scope', '$http', function (localStorageService, Users, Instruments, Songs, $scope, $http) {
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.user = Users.get({ id: vm.userId });

        $scope.postInstrument = function(){
            Instruments.save($scope.newInstrument);
        };

        $scope.postSong = function () {
            Songs.save($scope.newSong);
        };
            
        $scope.searchString = " ";

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

        $http.get("api/Users/" + vm.userId + "/songs")
            .success(function (data) {
                $scope.userSongs = data;
            })
            .error(function (err) { console.log(err.message); });

        $scope.addSongToUser = function(songId){
            $scope.user.userId = vm.userId;
            $scope.user.itemId = songId;
            $scope.user.collection = "songs";
            $scope.user.$addSong();
        };

        $scope.addInstrumentToUser = function(instrumentId){
            $scope.user.userId = vm.userId;
            $scope.user.itemId = instrumentId;
            $scope.user.collection = "instruments";
            $scope.user.$addInstrument();
        };

    }]);