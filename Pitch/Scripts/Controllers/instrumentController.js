'use strict';
angular.module('pitchApp')
    .controller('InstrumentController', ['$http', '$scope', 'Users', 'Instruments', 'instrumentFactory', 'localStorageService', function($http, $scope, Users, Instruments, instrumentFactory, localStorageService){
        var vm = this;
        vm.userId = localStorageService.get('authorizationData').userId;

        $scope.instruments = instrumentFactory.userInstruments;

        $scope.$watch('instruments', function(){
            instrumentFactory.updateInstruments($scope.instruments);
        });

        $scope.searchString = " ";

        $scope.searchInstruments = function () {
            if ($scope.searchString.length === 0) {
                $scope.searchInstrumentResults = [];
            }
            if ($scope.searchString.length > 2) {
                $http.get('api/Search/Instruments/' + $scope.searchString)
                    .success(function (data) {
                        $scope.searchInstrumentResults = data;
                    })
                    .error(function (err) { });
            };
        }

        $scope.postInstrument = function(){
            Instruments.save($scope.newInstrument);
        };

        $scope.addInstrumentToUser = function(instrument){
            var instrumentNotInArray = true;
            if ($scope.instruments.length > 0) {
                $scope.instruments.forEach(function(userInst){
                    if (userInst.id === instrument.id){
                        instrumentNotInArray = false;
                        return;
                    }
                });
            }
            if (instrumentNotInArray) {
                $scope.instruments.push(instrument);
                $scope.user.userId = vm.userId;
                $scope.user.itemId = instrument.id;
                $scope.user.collection = "instruments";
                $scope.user.$addInstrument();
            }
        };

        $scope.deleteInstrument = function(instrument){
            $http.delete('api/Users/' + vm.userId + '/Instruments/' + instrument.id)
                .then(function(){
                    var index = $scope.instruments.indexOf(instrument);
                    $scope.instruments.splice(index, 1);
                },
                function (err) {
                    console.log(err.message);
                })
        };
    }]);