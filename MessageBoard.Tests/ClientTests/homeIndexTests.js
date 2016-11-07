/// <reference path="../scripts/jasmine.js" />
/// <reference path="../../messageboard/scripts/angular.js" />
/// <reference path="../../messageboard/scripts/angular-mocks.js" />
/// <reference path="../../messageboard/js/home-index.js" />

describe("home-index Tests ->", function () {

    beforeEach(module('ngRoute'));

    beforeEach(function () {
        module("homeIndex");
    });

    var $httpBackend;

    beforeEach(inject(function ($injector) {
        $httpBackend = $injector.get("$httpBackend");
        $httpBackend.when("GET", "/api/v1/topics?includeReplies=true")
        .respond([
            {
                //mocked up object
                title: "first title",
                body: "some body of the topic",
                id: 1,
                created: "20050304"
            },
             {
                 title: "first title",
                 body: "some body of the topic",
                 id: 2,
                 created: "20050304"
             },
              {
                  title: "first title",
                  body: "some body of the topic",
                  id: 3,
                  created: "20050304"
              }
        ]);
    }));

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

    describe("dataService ->", function () {

        it("can load topics", inject(function (dataService) {
            expect(dataService.topics).toEqual([]);

            $httpBackend.expectGET("/api/v1/topics/?includeReplies=true");
            dataService.getTopics();
            $httpBackend.flush();
            expect(dataService.topics.length).toBeGreaterThan(0);
            expect(dataService.topics.length).toEqual(3);
        }))
    
    })

    describe("topicsController ->", function() {

        if ("load data", inject(function ($controller, $http, dataService) {
            var theScope = {};

            $httpBackend.expectGET("/api/v1/topics/?includeReplies=true");

            var ctrl = $controller("topicController", {
            $scope: theScope,
            $http: $http,
            dataService: dataService,
            });

            $httpBackend.flush();
            expect(ctrl).not.toBeNull();
            expect(theScope.data).toBeDefined();
        }));
    });

})