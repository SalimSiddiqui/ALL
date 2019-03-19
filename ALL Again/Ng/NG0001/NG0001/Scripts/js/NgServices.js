/// <reference path="../angular.js" />
/// service
var application = angular.module("mainapp", []);
application.service("random", function () {
    var num = Math.random() * 10;
    this.genNumber = function () {
        return num;
    }
});

application.controller("GetnumderCtrl", function ($scope, random) {
    $scope.GenerateNumber = function () {
        $scope.randomnumber = random.genNumber();
        $scope.rand = Math.random() * 10;
    };

});
application.controller("GetnumderCtrl2", function ($scope, random) {
    $scope.GenerateNumber2 = function () {
        $scope.randomnumber2 = random.genNumber();
    };

});
/////  factory

application.factory("randomser", function () {
    var genObj = {};
    var num = Math.random() * 10;
    genObj.GenerateNumber = function () {
        return num;
    }
    return genObj;
});

application.controller("GetnumderCtrl3", function ($scope, randomser) {
    $scope.GenerateNumber3 = function () {
        $scope.randomnumber3 = randomser.GenerateNumber();
    };

});

/////  Provider

application.provider("provider", function () {
    return {
        $get: function () {
            return {
                showDate: function () {
                    var date = new Date();
                    return date.getMilliseconds();
                }
            }
        }
    }
});
application.controller("GetnumderCtrl4", function ($scope, provider) {
    $scope.randomnumber4 = provider.showDate();
});


///-----------
application.controller("MyCtrl", function ($scope)
 { $scope.name = "Shailendra Chauhan" });
