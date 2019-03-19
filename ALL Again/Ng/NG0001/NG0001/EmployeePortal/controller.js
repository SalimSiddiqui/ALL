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
              $scope.Company = response.data;
          });
      };

      $scope.updateCompany = function (Company) {
          //Update Company.
          crudAPIFactory.updateCompany(Company).success(function (response) {
              crudAPIFactory.getCompanyList().success(function (response) {
                  $scope.Companies = response.data;
              });
              $scope.clearUI();
          });
      };

      $scope.deletecompany = function (Company) {
          //Update Company.
          crudAPIFactory.deletecompany(Company).success(function (response) {
              crudAPIFactory.getCompanyList().success(function (response) {
                  $scope.Companies = response.data;
              });
          });
      };

      //Get Company List
      crudAPIFactory.getCompanyList().success(function (response) {
          //$scope.Companies = response.data;
          console.log(response);
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