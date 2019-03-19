var apps = angular.module('myappss', []);
  
    apps.directive('ngDemo', function()  
    {  
        return  
        {  
            restrict: 'A',  
            template: "<div class="sparkline">This is simple Custom Directive of Element Type</div>" 
        }  
    }); 

apps.directive('myDomDirective', function () {
    return {
        link: function ($scope, element, attrs) {
            element.bind('click', function () {
                element.html('You clicked me!');
            });
            element.bind('mouseenter', function () {
                element.css('background-color', 'yellow');
            });
            element.bind('mouseleave', function () {
                element.css('background-color', 'white');
            });
        }
    };
});