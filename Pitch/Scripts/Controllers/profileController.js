'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['localStorageService', 'Users', 'Instruments', 'Songs', '$scope', function (localStorageService, Users, Instruments, Songs, $scope) {
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.user = Users.get({ id: vm.userId });

        $scope.postInstrument = function(){
            Instruments.save($scope.instrument);
        };

        $scope.postSong = function () {
            Songs.save($scope.song);
        };

    }]);