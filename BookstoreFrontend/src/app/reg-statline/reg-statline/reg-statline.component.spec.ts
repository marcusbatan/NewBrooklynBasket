/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RegStatlineComponent } from './reg-statline.component';

describe('RegStatlineComponent', () => {
  let component: RegStatlineComponent;
  let fixture: ComponentFixture<RegStatlineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegStatlineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegStatlineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
