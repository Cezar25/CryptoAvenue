import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppTradeDetailsComponent } from './app-trade-details.component';

describe('AppTradeDetailsComponent', () => {
  let component: AppTradeDetailsComponent;
  let fixture: ComponentFixture<AppTradeDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppTradeDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppTradeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
