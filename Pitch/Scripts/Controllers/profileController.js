'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['localStorageService', 'Users', 'Instruments', 'Songs', '$scope', function (localStorageService, Users, Instruments, Songs, $scope) {
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.user = Users.get({ id: vm.userId });

        $scope.postInstrument = function(){
            Instruments.save($scope.newInstrument);
        };

        $scope.songs = Songs.query();

        $scope.addSongToUser = function(songId){
            $scope.user.userId = vm.userId;
            $scope.user.songId = songId;
            $scope.user.songs = "songs";
            console.log($scope.user.songs);
            $scope.user.$addSong();
        };

        $scope.postSong = function () {
            Songs.save($scope.newSong);
        };

    }]);