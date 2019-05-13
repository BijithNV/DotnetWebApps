(function () {
    "use strict";

    angular.module("TwitterCloneControls", [])
        .directive("TwitterClonePostItem", TwitterClonePostItem);

    function TwitterClonePostItem() {
        return {
            scope: {
                TwitterClonePost: "=TwitterClonePost"
            },
            restrict: "E",
            templateUrl: "/views/TwitterClonePostItem.html"
        };
    }

    function compareTo() {
        return {
            require: "ngModel",
            scope: {
                otherModelValue: "=compareTo"
            },
            link: function (scope, element, attributes, ngModel) {

                ngModel.$validators.compareTo = function (modelValue) {
                    return modelValue == scope.otherModelValue;
                };

                scope.$watch("otherModelValue", function () {
                    ngModel.$validate();
                });
            }
        };
    };
})();
