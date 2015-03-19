angular.module('pitchApp')
    .factory('Song', ['$resource', function ($resource) {
        return $resource('/api/Instruments/:id');
    }]);