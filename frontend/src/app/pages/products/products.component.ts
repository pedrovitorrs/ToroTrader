import { Component, effect, inject, signal } from '@angular/core';
import { LayoutComponent } from '../../views/layout/layout.component';
import { PaginatorModule } from 'primeng/paginator';
import { Asset } from '../../core/services/assets.service';
import { CommonModule } from '@angular/common';
import { ProductsTableComponent } from './components/products-table/products-table.component';

@Component({
  selector: 'app-products',
  imports: [ProductsTableComponent, LayoutComponent],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {
}
