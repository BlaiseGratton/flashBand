angular.module('pitchApp')
    .factory('Users', ['$resource', function ($resource) {
        return $resource('/api/Users/:id/:collection/:itemId',
                        { id: '@userId',
                          collection: '@collection',
                          itemId: '@itemId'
                        },
                        { addSong: {
                                method: 'POST'
                            },
                          addInstrument: {
                                method: 'POST'
                            }
                        });
    }]);