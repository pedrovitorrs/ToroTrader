import { Component, OnInit, AfterViewInit } from '@angular/core';
import { LayoutNavBarComponent } from '../layout-nav-bar/layout-nav-bar.component';
import { LayoutFooterComponent } from '../layout-footer/layout-footer.component';
import { LayoutMenuComponent } from '../layout-menu/layout-menu.component';
import { LayoutAccountComponent } from '../layout-account/layout-account.component';

@Component({
  selector: 'app-layout',
  imports: [LayoutNavBarComponent, LayoutFooterComponent, LayoutMenuComponent],
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent {}