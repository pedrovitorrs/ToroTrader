import { Component, effect, inject, signal } from '@angular/core';
import {
  Order,
  OrderUser,
} from '../../../../core/services/Orders/OrdersResponse';
import { BasePaginatedComponent } from '../../../base/BasePaginatedComponent';
import { OrdersService } from '../../../../core/services/Orders/orders.service';
import { CommonModule, NgIf } from '@angular/common';
import { NgxChartsModule, ScaleType } from '@swimlane/ngx-charts';
import { Color } from '@swimlane/ngx-charts';

@Component({
  selector: 'app-summary-assets',
  standalone: true,
  imports: [NgIf, CommonModule, NgxChartsModule],
  templateUrl: './summary-assets.component.html',
  styleUrl: './summary-assets.component.scss',
})
export class SummaryAssetsComponent extends BasePaginatedComponent<Order> {
  private assetsService = inject(OrdersService);
  user = signal<OrderUser | null>(null);
  totalConcluidos = signal(0);
  chartData = signal<{ name: string; value: number }[]>([]);
  colorScheme: Color = {
    name: 'customScheme',
    selectable: true,
    group: ScaleType.Ordinal,
    domain: [
      '#64B5F6', // azul bebê
      '#03A9F4', // azul claro
      '#00BCD4', // ciano médio
      '#FFC107', // amarelo solar
      '#7E57C2', // roxo suave
      '#9575CD', // lilás claro
      '#81D4FA'  // azul céu
    ]
  };

  constructor() {
    super();
    effect(() => {
      this.fetchData();
    });
  }

  fetchData() {
    this.assetsService
      .getOrdersByUser(this.pageNumber(), 150)
      .subscribe((res) => {
        const concluidos =
          res.items?.filter((order) => order.status === 'Concluido') ?? [];

        console.log(concluidos)

        // Contar quantidade por bondAsset
        const grouped = concluidos.reduce((acc, item) => {
          acc[item.bondAsset] = (acc[item.bondAsset] ?? 0) + item.quantity;
          return acc;
        }, {} as Record<string, number>);

        console.log(grouped)

        const chart = Object.entries(grouped).map(([name, value]) => ({
          name,
          value,
        }));
        this.chartData.set(chart);

        this.items?.set(concluidos);
        this.totalElements?.set(res.totalElements ?? 0);
        this.user.set(res.user);
        this.totalConcluidos.set(concluidos.length);
      });
  }
}
