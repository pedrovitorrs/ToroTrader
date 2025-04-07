import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SummaryAssetsComponent } from './summary-assets.component';

describe('SummaryAssetsComponent', () => {
  let component: SummaryAssetsComponent;
  let fixture: ComponentFixture<SummaryAssetsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SummaryAssetsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SummaryAssetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
