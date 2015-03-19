angular.module('pitchApp')
    .factory('Instrument', ['$resource', function ($resource) {
        return $resource('/api/Instruments/:id');
    }]);