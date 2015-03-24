'use strict';
angular.module('pitchApp')
    .controller('SongController', ['$http', '$scope', 'Users', 'Songs', 'localStorageService', function($http, $scope, Users, Songs, localStorageService){
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.user = Users.get({ id: vm.userId });

        $http.get("api/Users/" + vm.userId + "/Songs")
            .success(function (data) {
                $scope.songs = data;
            })
            .error(function (err) { console.log(err.message); })

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

        $scope.postSong = function () {
            Songs.save($scope.newSong);
        };

        $scope.addSongToUser = function (songId) {
            $scope.user.userId = vm.userId;
            $scope.user.itemId = songId;
            $scope.user.collection = "songs";
            $scope.user.$addSong();
        };


    }]);