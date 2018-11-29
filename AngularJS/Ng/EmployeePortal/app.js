var crudFactoryApp = angular.module('crudFactoryApp', []);

angular.module('crudFactoryApp', [
  'crudFactoryApp.controller',
  'crudFactoryApp.crudFactory',
  'ngRoute'
]).
config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
      //when("/", {templateUrl: "partials/home.html", controller: "companyController"}).
      otherwise({ templateUrl: "partials/home.html", controller: "companyController" });
}]);