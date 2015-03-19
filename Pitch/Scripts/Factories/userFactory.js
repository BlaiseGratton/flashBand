angular.module('pitchApp')
    .factory('Users', ['$resource', function ($resource) {
        return $resource('/api/Users/:id/:collection/:itemId',
                        { id: '@userId',
                          collection: '@songs',
                          itemId: '@songId'
                        },
                        { addSong: {
                                method: "POST"
                            }
                        });
    }]);