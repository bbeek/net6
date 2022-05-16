import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsentstarterComponent } from './consentstarter.component';

describe('ConsentstarterComponent', () => {
    let component: ConsentstarterComponent;
    let fixture: ComponentFixture<ConsentstarterComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [ConsentstarterComponent],
        }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(ConsentstarterComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
