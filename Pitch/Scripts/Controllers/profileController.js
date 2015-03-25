'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['localStorageService', 'Users', 'Instruments', 'songFactory', 'instrumentFactory', '$scope', '$http', function (localStorageService, Users, Instruments, songFactory, instrumentFactory, $scope, $http) {
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;
        $scope.user = Users.get({ id: vm.userId });

        $scope.songs = songFactory.userSongs;

        $scope.$on('valuesUpdated', function(){
            $scope.songs = songFactory.userSongs;
            $scope.instruments = instrumentFactory.userInstruments;
        });

        $scope.$on('valuesUpdated', function(){
            $scope.songs = songFactory.userSongs;
            $scope.instruments = instrumentFactory.userInstruments;
        });
    }]);