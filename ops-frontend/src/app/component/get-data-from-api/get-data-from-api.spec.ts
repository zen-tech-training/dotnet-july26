import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetDataFromAPI } from './get-data-from-api';

describe('GetDataFromAPI', () => {
  let component: GetDataFromAPI;
  let fixture: ComponentFixture<GetDataFromAPI>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetDataFromAPI],
    }).compileComponents();

    fixture = TestBed.createComponent(GetDataFromAPI);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
