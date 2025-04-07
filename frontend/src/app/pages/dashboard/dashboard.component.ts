import { Component } from '@angular/core';
import { LayoutComponent } from '../../views/layout/layout.component';
import { PaginatorModule } from 'primeng/paginator';
import { AssetsTableComponent } from './components/assets-table/assets-table.component';
import { SummaryAssetsComponent } from './components/summary-assets/summary-assets.component';

@Component({
  selector: 'app-dashboard',
  imports: [PaginatorModule, LayoutComponent, AssetsTableComponent, SummaryAssetsComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {

  public constructor() {
  }
}