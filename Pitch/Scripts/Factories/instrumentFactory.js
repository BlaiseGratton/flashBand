angular.module('pitchApp')
    .factory('Instruments', ['$resource', function ($resource) {
        return $resource('/api/Instruments/:id');
    }]);