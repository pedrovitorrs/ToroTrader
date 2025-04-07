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

  public constructor() {
  }
}