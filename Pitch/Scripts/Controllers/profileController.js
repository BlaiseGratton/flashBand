'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['localStorageService', 'Instrument', 'Song', '$scope', function (localStorageService, Instrument, Song, $scope) {
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        vm.loadPlayer = function (id) {
            $scope.user = players.get({ id: id });
            console.log($scope.user);
        };

        $scope.postInstrument = function(){
            Instrument.save($scope.instrument);
        };

        $scope.postSong = function () {
            $scope.song = new Song();
            Song.save();
        };

    }]);