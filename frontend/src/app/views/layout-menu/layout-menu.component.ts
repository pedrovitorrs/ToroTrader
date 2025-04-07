import { Router } from '@angular/router';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ScriptsService } from '../scripts.service';


@Component({
  selector: 'app-layout-menu',
  templateUrl: './layout-menu.component.html',
  styleUrls: ['./layout-menu.component.scss']
})
export class LayoutMenuComponent  implements OnInit, AfterViewInit{

  public constructor(private _scripts:ScriptsService,
    public router: Router
  ) {
    this.router.events.subscribe(() => this.updateMenuState());
  }

  public ngAfterViewInit(): void {
    this._scripts.loadMenuScripts();
  }

  public createUrl(route: string): string {
    return this.router.serializeUrl(this.router.createUrlTree([route]));
  }

  // Função para atualizar o estado dos itens de menu
  public updateMenuState(): void {
    const menuItems = document.querySelectorAll('.menu-item');

    // Itera sobre os elementos selecionados e remove a classe 'active'
    menuItems.forEach(item => {
        item.classList.remove('active');
    });

    const menuItemsComAtivos = document.querySelectorAll('.menu-item > a.active');

    // Itera sobre os elementos selecionados para listar os pais (os .menu-item)
    menuItemsComAtivos.forEach(item => {
        const menuItem = item.closest('.menu-item');
        if (menuItem) {
            menuItem.classList.add('active');
        }
    });
  }

  public ngOnInit(): void {
  }

  public dashboard(): void {
    this.router.navigateByUrl('/dashboard');
  }

  public products(): void {
    //this.authorization.logOut();
    this.router.navigateByUrl('/products');
  }
}

