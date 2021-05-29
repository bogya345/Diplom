"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var http_serviceHomeworkListTeacher_1 = require("./http.serviceHomeworkListTeacher");
describe('HomeworkListTeacherService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(http_serviceHomeworkListTeacher_1.homeworkListTeacher_HttpService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=homework-list-teacher.service.spec.js.map