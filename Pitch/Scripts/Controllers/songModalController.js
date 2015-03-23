'use strict';
angular.module('pitchApp')
    .controller('SongModalController', ['$scope', '$modal', '$log', function($scope, $modal, $log){
        $scope.open = function(size){
            var modalInstance = $modal.open({
                templateUrl: '../../Static/Views/_song-modal.html',
                controller: '',
                size: size
            });
            modalInstance.result.then(function (selectedItem) {
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };
    }]);