(function () {
    'use strict';

    angular
        .module('angularDemoApp')
        .controller('homeController', homeController);

    homeController.$inject = ['$location']; 

    function homeController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'homeController';
        
        activate();

        function activate() { }
    }
})();
