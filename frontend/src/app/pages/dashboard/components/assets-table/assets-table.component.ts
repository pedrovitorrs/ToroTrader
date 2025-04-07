import { Component, effect, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginatorModule } from 'primeng/paginator';
import { AsyncPipe } from '@angular/common';
import { NgFor } from '@angular/common';
import { Asset, AssetsService } from '../../../../core/services/assets.service';

@Component({
  selector: 'app-assets-table',
  standalone: true,
  imports: [CommonModule, PaginatorModule,  NgFor],
  templateUrl: './assets-table.component.html',
})
export class AssetsTableComponent {
  private assetsService = inject(AssetsService);

  // signals para armazenar paginação e dados
  pageNumber = signal(1);
  pageSize = signal(10);

  items? = signal<Asset[]>([]);
  totalElements? = signal(0);

  constructor() {
    // Effect para buscar dados ao iniciar ou trocar página
    effect(() => {
      this.fetchAssets();
    });
  }

  fetchAssets() {
    this.assetsService.getAssets(this.pageNumber(), this.pageSize()).subscribe((res) => {
      this.items?.set(res.items ?? []);
      this.totalElements?.set(res.totalElements ?? 0);
    });
  }

  handlePageChange(event: any) {
    this.pageNumber.set(event.page + 1);
    this.pageSize.set(event.rows);
  }
}
