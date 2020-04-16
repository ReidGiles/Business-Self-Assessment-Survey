angular.module('SurveyApp', [])
    .controller('SurveyCtrl', function ($scope, $http) {
        $scope.categoryTitle = "Loading Categories";
        $scope.questionTitle = "Loading Question";
        $scope.categories = [];
        $scope.currentCategory;
        $scope.questions = [];
        $scope.options = [];
        $scope.questionAnswers = [];
        $scope.submitCategory = false;
        $scope.otherText;
        $scope.btnCategorySubmit = "Submit Category";

        $http.get("/api/survey/").then(function (data, status, headers, config) {
            angular.forEach(data.data, function (value, key) {
                $scope.categories.push(value);               
            });
            $scope.changeCategory($scope.categories[0]);
        });

        $scope.changeCategory = function (category) {
            $scope.questions = [];
            $scope.options = [];
            if (category) {
                $scope.currentCategory = category;

                $http.get("/api/survey/" + category.id).then(function (data, status, headers, config) {
                    angular.forEach(data.data.surveyQuestions, function (value, key) {
                        $scope.questions.push(value);

                        angular.forEach(value.options, function (value, key) {
                            $scope.options.push(value);
                        });
                    });
                    if ($scope.categoryTitle) {
                        $scope.categoryTitle = data.data.title
                    }
                });
            }
            else {
                $scope.categoryTitle = "All categories complete, please request results";
            }
            
        }

        $scope.storeAnswer = function (question, answer) {
            if ($scope.questionAnswers.findIndex(x => x.key.title === question.title) != -1) {
                $scope.questionAnswers[$scope.questionAnswers.findIndex(x => x.key.title === question.title)].value = answer;
            }
            else {
                $scope.questionAnswers.push({
                    key: question,
                    value: answer,
                    category: $scope.currentCategory,
                    other : $scope.otherText
                });
            }

            console.log(question.title + ": " + answer.title);
        }

        $scope.storeText = function (question, text) {
            if ($scope.questionAnswers.findIndex(x => x.key.title === question.title) != -1) {
                $scope.questionAnswers[$scope.questionAnswers.findIndex(x => x.key.title === question.title)].other = text;
            }
            else {
                $scope.questionAnswers.push({
                    key: question,
                    value: answer,
                    category: $scope.currentCategory,
                    other: $scope.otherText
                });
            }

            console.log(question.title + ": " + answer.title);
        }

        $scope.submitCategory = function () {
            angular.forEach($scope.categories, function (value, key) {
                if (value.title === $scope.currentCategory.title) {
                    index = $scope.categories.findIndex(x => x.title === $scope.currentCategory.title);
                    $scope.categories.splice(index, 1);
                    $scope.changeCategory($scope.categories[0]);
                }
            });
        }

        $scope.requestResults = function () {
            $scope.questions = [];
            $scope.options = [];
        }
    });