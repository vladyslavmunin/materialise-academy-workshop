(function () {
    'use strict';

    angular
        .module('angularDemoApp')
        .factory('criminalFactory', criminalFactory);

    criminalFactory.$inject = ['$http'];

    function criminalFactory($http) {
        var service = {
            getPokemon: getPokemon
        };

        return service;

        function getPokemon() {
            return $http.get("https://pokeapi.co/api/v2/pokemon-form/1/");
        }
    }
})();