import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrendingProductsTableComponent } from './trending-products-table.component';

describe('TrendingProductsTableComponent', () => {
  let component: TrendingProductsTableComponent;
  let fixture: ComponentFixture<TrendingProductsTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TrendingProductsTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrendingProductsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
