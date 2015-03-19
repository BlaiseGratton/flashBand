'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['localStorageService', 'Instruments', 'Songs', '$scope', function (localStorageService, Instruments, Songs, $scope) {
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        vm.loadPlayer = function (id) {
            $scope.user = players.get({ id: id });
            console.log($scope.user);
        };

        $scope.postInstrument = function(){
            Instruments.save($scope.instrument);
        };

        $scope.postSong = function () {
            Songs.save($scope.song);
        };

    }]);