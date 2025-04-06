import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LayoutAccountComponent } from './views/layout-account/layout-account.component';
import { LayoutComponent } from './views/layout/layout.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'toro-trader-ui';
}
