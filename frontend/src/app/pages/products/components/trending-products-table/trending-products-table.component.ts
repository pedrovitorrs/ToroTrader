import { Component, effect, inject } from '@angular/core';
import { Router } from '@angular/router';
import { BasePaginatedComponent } from '../../../base/BasePaginatedComponent';
import { BuyDialogComponent } from '../buy-dialog/buy-dialog.component';
import { PaginatorModule } from 'primeng/paginator';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { FormsModule } from '@angular/forms';
import { InputNumberModule } from 'primeng/inputnumber';
import { Product, ProductsService } from '../../../../core/services/Products/products.service';

@Component({
  selector: 'app-trending-products-table',
  standalone: true,
  imports: [CommonModule, PaginatorModule, TableModule , DialogModule,
    FormsModule,
    InputNumberModule, BuyDialogComponent],
  templateUrl: './trending-products-table.component.html',
  styleUrl: './trending-products-table.component.scss'
})
export class TrendingProductsTableComponent extends BasePaginatedComponent<Product>{
  private productsService = inject(ProductsService);
  private router = inject(Router);

  buyDialogVisible = false;
  selectedProduct: Product | null = null;
  buyQuantity = 1;

  constructor() {
    super();
    effect(() => {
      this.fetchData();
    });
  }

  fetchData() {
    this.productsService.getTopTraded(this.pageNumber(), this.pageSize()).subscribe((res) => {
      this.items?.set(res.items ?? []);
      this.totalElements?.set(res.totalElements ?? 0);
      console.log(this.items)
    });
  }

  openBuyDialog(item: Product) {
    this.selectedProduct = item;
    this.buyQuantity = 1;
    this.buyDialogVisible = true;
  }

  handleBuy(product: Product) {
    this.selectedProduct = product;
    this.buyQuantity = 1;
    this.buyDialogVisible = true;
  }

  public products(): void {
    //this.authorization.logOut();
    this.router.navigateByUrl('/products');
  }
}
