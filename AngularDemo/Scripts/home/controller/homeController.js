(function () {
    'use strict';

    angular
        .module('angularDemoApp')
        .controller('homeController', homeController);

    homeController.$inject = ['criminalFactory'];

    function homeController(criminalFactory) {
        /* jshint validthis:true */
        var vm = this;
        vm.getPokemon = getPokemon; 
        vm.title = 'homeController';
        
        activate();

        function activate() {
            vm.getPokemon();
        }

        function getPokemon() {
            criminalFactory.getPokemon()
                .success(function (result) {
                    vm.pokemon = result;
                })
                .catch(function (exception) {
                    var ex = exception;
                });
        };
    }
})();
