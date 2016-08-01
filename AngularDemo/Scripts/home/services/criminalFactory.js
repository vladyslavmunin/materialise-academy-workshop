(function () {
    'use strict';

    angular
        .module('angularDemoApp')
        .factory('criminalFactory', criminalFactory);

    criminalFactory.$inject = ['$http'];

    function criminalFactory($http) {
        var service = {
            getData: getData,
            getPokemon: getPokemon
        };

        return service;

        function getData() {
            alert('hello, i am a new factory');
        }

        function getPokemon() {
            return $http.get("https://pokeapi.co/api/v2/pokemon-form/1/");
        }
    }
})();