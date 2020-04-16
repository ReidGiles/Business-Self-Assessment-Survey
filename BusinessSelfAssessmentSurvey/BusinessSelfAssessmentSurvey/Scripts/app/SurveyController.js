angular.module('SurveyApp', [])
    .controller('SurveyCtrl', function ($scope, $http) {
        $scope.categoryTitle = "Please select a category to begin";
        $scope.questionTitle = "Loading Question";
        $scope.categories = [];
        $scope.questions = [];
        $scope.options = [];

        $http.get("/api/survey/").then(function (data, status, headers, config) {
            angular.forEach(data.data, function (value, key) {
                $scope.categories.push(value);
            });
        });

        $scope.changeCategory = function (category) {
            $scope.questions = [];
            $scope.options = [];

            $scope.categoryTitle = category.title;

            $http.get("/api/survey/" + category.id).then(function (data, status, headers, config) {
                angular.forEach(data.data.surveyQuestions, function (value, key) {
                    $scope.questions.push(value);

                    angular.forEach(value.options, function (value, key) {
                        $scope.options.push(value);
                    });
                });

                $scope.categoryTitle = data.data.title
            });
        }
    });