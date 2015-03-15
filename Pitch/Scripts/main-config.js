;(function(){
  'use strict';
  
    angular.module('pitchApp')
        .config(['$routeProvider', function($routeProvider){
            $routeProvider
            .when('/prof', {
                templateUrl: 'Static/Views/profile.html',
                controller: 'ProfileController',
                controllerAs: 'profCtrl',
                //private: true
            })
            .when('/prof/edit', {
                templateUrl: 'Static/Views/edit-profile.html',
                controller: 'EditProfileController',
                controllerAs: 'profCtrl',
                //private: true
            })
            .when('/', {
                templateUrl: 'Views/Home/index.cshtml'
            })
            .otherwise({redirectTo: '/'});
        }])
}());