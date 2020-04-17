﻿angular.module('SurveyApp', [])
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

        $scope.storeAnswer = function (pQuestion, pAnswer) {
            var exists = false;
            var index;
            angular.forEach($scope.questionAnswers, function (value, key) {
                if (value.question === pQuestion.title) {
                    exists = true;
                    index = $scope.questionAnswers.indexOf(value);
                }
            });

            if (exists == true) {
                $scope.questionAnswers[index].answer = pAnswer.title;
            }
            else {
                $scope.questionAnswers.push({
                    question: pQuestion.title,
                    answer: pAnswer.title,
                    category: $scope.currentCategory.title,
                    other : $scope.otherText
                });
            }

            console.log(pQuestion.title + ": " + pAnswer.title);
        }

        $scope.storeText = function (pQuestion, text) {
            var exists = false;
            var index;
            angular.forEach($scope.questionAnswers, function (value, key) {
                if (value.question === pQuestion.title) {
                    exists = true;
                    index = $scope.questionAnswers.indexOf(value);
                }
            });

            if (exists == true) {
                $scope.questionAnswers[index].other = text;
            }
            else {
                $scope.questionAnswers.push({
                    question: pQuestion.title,
                    option: undefined,
                    category: $scope.currentCategory.title,
                    other: text
                });
            }

            console.log(pQuestion.title + ": " + pAnswer.title);
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

            $http.post("/api/survey/", JSON.stringify($scope.questionAnswers)).then(function (data, status, headers, config) {
            });
        }
    });