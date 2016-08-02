(function() {
    'use strict';

    angular
        .module('angularDemoApp')
        .directive('nameDirective', nameDirective);

    nameDirective.$inject = ['$window'];
    
    function nameDirective ($window) {
      
        var directive = {
            link: link,
            require: '?ngModel',
            restrict: 'A'
        
        };
        return directive;

        function link(scope, element, attrs, mCtrl) {
            function ValidateName(value) {
                if (!mCtrl) {
                    return;
                }
                if (value === 'Vlados') {
                    mCtrl.$setValidity('name',true);
                }
                else {
                    mCtrl.$setValidity('name', false);
                }
                return value;
            }
            mCtrl.$parsers.push(ValidateName);
        };
    }

})();