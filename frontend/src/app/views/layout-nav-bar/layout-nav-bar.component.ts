import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { TokenService } from '../../shared/TokenService';
import { TokenModel } from '../../shared/TokenModel';
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
  public token!: TokenModel;
  public userModel!:UserModel;

  public constructor(
    private router: Router,
    private tokenService: TokenService
  ) { }

  public ngOnInit(): void {
    this.tokenService.dadosToken$.subscribe((token) => {
      if (token) {
        this.userModel = {
          name: token['User.Name'],
          documentNumber: token['User.DocumentNumber'],
          accountId: token['User.AccountId'],
          clientId: token['User.ClientId']
        };
      }

      console.log('Token recebido no componente:', token);
    });
  }

  public signOut(): void {
    //this.authorization.logOut();
    this.router.navigateByUrl('/auth');
  }
}

interface UserModel {
  name: string
  documentNumber: string,
  accountId: string,
  clientId: string
};
