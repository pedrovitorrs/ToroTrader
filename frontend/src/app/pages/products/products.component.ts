import { Component, effect, inject, signal } from '@angular/core';
import { LayoutComponent } from '../../views/layout/layout.component';
import { PaginatorModule } from 'primeng/paginator';
import { CommonModule, NgIf } from '@angular/common';
import { ProductsTableComponent } from './components/products-table/products-table.component';
import { ActivatedRoute } from '@angular/router';
import { TrendingProductsTableComponent } from './components/trending-products-table/trending-products-table.component';

@Component({
  selector: 'app-products',
  imports: [ProductsTableComponent, LayoutComponent, TrendingProductsTableComponent, NgIf],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {
  showTrending = false;

  constructor(private route: ActivatedRoute) {
    this.route.queryParams.subscribe(params => {
      this.showTrending = params['trending'] === 'true';
    });
  }
}
