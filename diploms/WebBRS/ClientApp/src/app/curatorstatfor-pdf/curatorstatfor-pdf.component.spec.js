"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var curatorstatfor_pdf_component_1 = require("./curatorstatfor-pdf.component");
describe('CuratorstatforPDFComponent', function () {
    var component;
    var fixture;
    beforeEach(testing_1.async(function () {
        testing_1.TestBed.configureTestingModule({
            declarations: [curatorstatfor_pdf_component_1.CuratorstatforPDFComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = testing_1.TestBed.createComponent(curatorstatfor_pdf_component_1.CuratorstatforPDFComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=curatorstatfor-pdf.component.spec.js.map