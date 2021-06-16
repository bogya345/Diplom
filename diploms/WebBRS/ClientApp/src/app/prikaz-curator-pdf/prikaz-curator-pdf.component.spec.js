"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var prikaz_curator_pdf_component_1 = require("./prikaz-curator-pdf.component");
describe('PrikazCuratorPDFComponent', function () {
    var component;
    var fixture;
    beforeEach(testing_1.async(function () {
        testing_1.TestBed.configureTestingModule({
            declarations: [prikaz_curator_pdf_component_1.PrikazCuratorPDFComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = testing_1.TestBed.createComponent(prikaz_curator_pdf_component_1.PrikazCuratorPDFComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=prikaz-curator-pdf.component.spec.js.map