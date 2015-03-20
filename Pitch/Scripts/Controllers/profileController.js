'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['localStorageService', 'Users', 'Instruments', 'Songs', '$scope', function (localStorageService, Users, Instruments, Songs, $scope) {
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.user = Users.get({ id: vm.userId });

        $scope.postInstrument = function(){
            Instruments.save($scope.newInstrument);
        };

        $scope.postSong = function () {
            Songs.save($scope.newSong);
        };

        $scope.songs = Songs.query();

        $scope.instruments = Instruments.query();

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