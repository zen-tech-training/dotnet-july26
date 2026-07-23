import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DecodeJwtToken } from './decode-jwt-token';

describe('DecodeJwtToken', () => {
  let component: DecodeJwtToken;
  let fixture: ComponentFixture<DecodeJwtToken>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DecodeJwtToken],
    }).compileComponents();

    fixture = TestBed.createComponent(DecodeJwtToken);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
