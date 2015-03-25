'use strict';
angular.module('pitchApp')
    .controller('SongController', ['$http', '$scope', 'Users', 'Songs', 'songFactory', 'localStorageService', function($http, $scope, Users, Songs, songFactory, localStorageService){
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.songs = songFactory.userSongs;

        $scope.$watch('songs', function(){
            songFactory.updateSongs($scope.songs);
        });

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

        $scope.addSongToUser = function(song){
            var songNotInArray = true;
            if ($scope.songs.length > 0) {
                $scope.songs.forEach(function (userSong) {
                    if (userSong.id === song.id) {
                        songNotInArray = false;
                        return;
                    }
                });
            }
            if (songNotInArray) {
                $scope.songs.push(song);
                $scope.user.userId = vm.userId;
                $scope.user.itemId = song.id;
                $scope.user.collection = "songs";
                $scope.user.$addSong();
            }
        };

        $scope.deleteSong = function(song){
            $http.delete('api/Users/' + vm.userId + '/Songs/' + song.id)
                .then(function(){
                    var index = $scope.songs.indexOf(song);
                    $scope.songs.splice(index, 1);
                },
                function (err) {
                    console.log(err.message);
                })
        };
    }]);