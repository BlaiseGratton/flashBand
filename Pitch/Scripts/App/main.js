'use strict';
angular.module('pitchApp', ['ngRoute', 'ngResource', 'LocalStorageModule'])
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    })