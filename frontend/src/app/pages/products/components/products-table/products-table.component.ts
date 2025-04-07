import { CommonModule } from '@angular/common';
import { Component, effect, inject, signal } from '@angular/core';
import { PaginatorModule } from 'primeng/paginator';
import { LayoutComponent } from '../../../../views/layout/layout.component';
import { Product, ProductsService } from '../../../../core/services/products.service';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { FormsModule } from '@angular/forms';
import { InputNumberModule } from 'primeng/inputnumber';
import { BuyDialogComponent } from '../buy-dialog/buy-dialog.component';
import { Router } from '@angular/router';
import { BasePaginatedComponent } from '../../../base/BasePaginatedComponent';


@Component({
  selector: 'app-products-table',
  standalone: true,
  imports: [CommonModule, PaginatorModule, TableModule , DialogModule,
    FormsModule,
    InputNumberModule, BuyDialogComponent],
  templateUrl: './products-table.component.html',
  styleUrl: './products-table.component.scss'
})
export class ProductsTableComponent extends BasePaginatedComponent<Product>{
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
      this.productsService.getAllProducts(this.pageNumber(), this.pageSize()).subscribe((res) => {
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

    public trendingProducts(): void {
      //this.authorization.logOut();
      this.router.navigateByUrl('/dashboard');
    }
}
