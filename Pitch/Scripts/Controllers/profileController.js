'use strict';
angular.module('pitchApp')
    .controller('ProfileController', ['localStorageService', 'Users', 'Instruments', 'songFactory', '$scope', '$http', function (localStorageService, Users, Instruments, songFactory, $scope, $http) {
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.user = Users.get({ id: vm.userId });

        $scope.songs = songFactory.userSongs;

        $scope.$on('valuesUpdated', function(){
            $scope.songs = songFactory.userSongs;
        });

        $http.get("api/Users/" + vm.userId + "/Instruments")
            .success(function (data) {
                $scope.instruments = data;
            })
            .error(function (err) { console.log(err.message); })

        $scope.addInstrumentToUser = function(instrumentId){
            $scope.user.userId = vm.userId;
            $scope.user.itemId = instrumentId;
            $scope.user.collection = "instruments";
            $scope.user.$addInstrument();
        };

    }]);