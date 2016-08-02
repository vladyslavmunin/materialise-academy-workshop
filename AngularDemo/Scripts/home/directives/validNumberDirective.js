(function() {
    'use strict';

    angular
        .module('angularDemoApp')
        .directive('validNumber', validNumber);

    validNumber.$inject = [];
    
    function validNumber() {
        var directive = {
            link: link,
            restrict: 'A'
        };
        return directive;

        function link(scope, element, attrs) {
            alert('hello');
        }
    }

})();