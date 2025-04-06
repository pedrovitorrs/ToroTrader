import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
//import { AuthorizationService } from 'src/app/core/services/authorization.services';

@Component({
  selector: 'app-layout-nav-bar',
  imports: [
    CommonModule,
    MatMenuModule, 
    MatButtonModule,
    MatIconModule,
  ],
  templateUrl: './layout-nav-bar.component.html',
  styleUrls: ['./layout-nav-bar.component.scss'],
})
export class LayoutNavBarComponent implements OnInit {
  public token!: any;
  public constructor(
    private router: Router,
    //private authorization: AuthorizationService
  ) { }

  public ngOnInit(): void {
    //this.authorization.getToken().subscribe((token) => {
    //  this.token = token;
    //});
  }

  public signOut(): void {
    //this.authorization.logOut();
    this.router.navigateByUrl('/auth');
  }
}
