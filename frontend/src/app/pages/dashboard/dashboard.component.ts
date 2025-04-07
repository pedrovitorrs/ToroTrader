import { Component } from '@angular/core';
import { LayoutComponent } from '../../views/layout/layout.component';
import { LayoutNavBarComponent } from '../../views/layout-nav-bar/layout-nav-bar.component';
import { PaginatorModule } from 'primeng/paginator';
import { AssetsTableComponent } from './components/assets-table/assets-table.component';

@Component({
  selector: 'app-dashboard',
  imports: [PaginatorModule, LayoutComponent, AssetsTableComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
  public date: Date = new Date();
  public totalizador: TotalizadoresResponse = {
    agendados: 10,
    concluidos: 20,
    lucro: 20,
    receber: 3
  };

  public constructor() {
  }

  onPageChange(event: any) {
    const page = event.page + 1; // começa do 0
    const size = event.rows;
    //this.getServicos({ pageIndex: page, pageSize: size });
  }
}

export interface TotalizadoresResponse {
  agendados: number,
  concluidos: number,
  lucro: number,
  receber: number
}