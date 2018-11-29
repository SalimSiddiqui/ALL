angular.module('crudFactoryApp.crudFactory', [])
  .factory('crudAPIFactory', function ($http) {

      var crudFactory = {};

      //Get Company List
      crudFactory.getCompanyList = function () {
          return $http({
              // url: "http://localhost:8080/SpringMavenRestDemoService/getcompanyall/",
              url: "../WebService/DDL_Service.asmx/GetCompData",
              method: 'GET'
          });
      };

      //Insert new Company.
      crudFactory.createCompany = function (Company) {
         
          var obj = {};
          obj.Company = Company;
          console.log(obj.Company);
          return $http({
              url: '../WebService/DDL_Service.asmx/InsertCompData',           
              method: 'POST',
              //headers: {
              //    "Content-Type": "application/json"
              //},
              data: obj
          });
         
         
      };

      //Get Company.
      crudFactory.getCompany = function (Company) {
         
          return $http({
            //  url: "http://localhost:8080/SpringMavenRestDemoService/getcompany/" + Company.companyId,
              url: '../WebService/DDL_Service.asmx/CompData?companyId=' + Company.companyId,
              method: 'GET',
          });
      };

      //Update Company.
      crudFactory.updateCompany = function (Company) {
          var obj = {};
          obj.Company = Company;
          return $http({
              url: '../WebService/DDL_Service.asmx/CompDataUpdate',
              method: 'POST',
              data: obj,
          });
      };

      //Delete Company.
      crudFactory.deletecompany = function (Company) {
          return $http({
              url: '../WebService/DDL_Service.asmx/CompDatadelete?companyId=' + Company.companyId,
              method: 'GET',
          });
      };

      return crudFactory;
  });