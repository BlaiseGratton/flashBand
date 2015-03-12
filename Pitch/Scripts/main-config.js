;(function(){
  'use strict';
  
    angular.module('pitchApp')
        .config(function($routeProvider){
            $routeProvider
            .when('/', {
                templateUrl: '/Views/Home/index.cshtml'
            })
            .otherwise({redirectTo: '/'});
        })
}());