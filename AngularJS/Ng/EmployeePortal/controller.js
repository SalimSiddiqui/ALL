angular.module('crudFactoryApp.controller', []).

   /* Company controller */
  controller('companyController', function ($scope, crudAPIFactory) {
      $scope.createCompany = function (Company) {
          //Insert new Company.
          crudAPIFactory.createCompany(Company).success(function (response) {
              crudAPIFactory.getCompanyList().success(function (response) {
                  $scope.Companies = response;
                  $scope.clearUI();
              });

          });
      };

      $scope.getCompany = function (Company) {
          //Get Company.
          crudAPIFactory.getCompany(Company).success(function (response) {
              // one Way to define object 
              $scope.Company = {};            
              $scope.Company.name = response[0].name
             
              // Other way to defind Object 
              $scope.Company = {
                  companyId: response[0].companyId,
                  name: response[0].name,
                  ceo: response[0].ceo,
                  country: response[0].country,
                  foundationYear: response[0].foundationYear,
                  noOfEmployee: response[0].noOfEmployee
              };             
          });
      };

      $scope.updateCompany = function (Company) {
          //Update Company.
          crudAPIFactory.updateCompany(Company).success(function (response) {
              crudAPIFactory.getCompanyList().success(function (response) {
                  $scope.Companies = response;
              });
              $scope.clearUI();
          });
      };

      $scope.deletecompany = function (Company) {
          //Update Company.
          crudAPIFactory.deletecompany(Company).success(function (response) {
              crudAPIFactory.getCompanyList().success(function (response) {
                  $scope.Companies = response;
              });
          });
      };

      //Get Company List
      crudAPIFactory.getCompanyList().success(function (response) {
          //$scope.Companies = response.data;
         
          $scope.Companies = response;
      });

      $scope.clearUI = function () {
          $scope.Company.companyId = "";
          $scope.Company.name = "";
          $scope.Company.ceo = "";
          $scope.Company.country = "";
          $scope.Company.foundationYear = "";
          $scope.Company.noOfEmployee = "";
      };

  });