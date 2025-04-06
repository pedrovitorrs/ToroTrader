import { Component } from '@angular/core';
import { LayoutComponent } from '../../views/layout/layout.component';
import { LayoutNavBarComponent } from '../../views/layout-nav-bar/layout-nav-bar.component';

@Component({
  selector: 'app-dashboard',
  imports: [LayoutComponent],
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
}

export interface TotalizadoresResponse {
  agendados: number,
  concluidos: number,
  lucro: number,
  receber: number
}