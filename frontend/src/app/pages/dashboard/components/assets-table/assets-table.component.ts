import { Component, effect, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginatorModule } from 'primeng/paginator';
import { TableModule } from 'primeng/table';
import { BasePaginatedComponent } from '../../../base/BasePaginatedComponent';
import { OrdersService } from '../../../../core/services/Orders/orders.service';
import { Order } from '../../../../core/services/Orders/OrdersResponse';

@Component({
  selector: 'app-assets-table',
  standalone: true,
  imports: [CommonModule, PaginatorModule,  TableModule],
  templateUrl: './assets-table.component.html',
})
export class AssetsTableComponent extends BasePaginatedComponent<Order>{
  private assetsService = inject(OrdersService);

  constructor() {
    super();
    effect(() => {
      this.fetchData();
    });
  }

  fetchData() {
    this.assetsService.getOrdersByUser(this.pageNumber(), this.pageSize()).subscribe((res) => {
      this.items?.set(res.items ?? []);
      this.totalElements?.set(res.totalElements ?? 0);

      console.log(res.totalElements)
    });
  }

  getStatusClass(status: string): string {
    switch (status) {
      case 'Pendente':
        return 'badge bg-warning text-dark'; // amarelo
      case 'Concluido':
        return 'badge bg-success'; // verde
      case 'Cancelado':
        return 'badge bg-secondary'; // cinza
      case 'Erro':
        return 'badge bg-danger'; // vermelho
      default:
        return 'badge bg-light text-dark'; // neutro
    }
  }
}
