// src/app/shared/base/base-paginated.component.ts
import { signal } from '@angular/core';

export abstract class BasePaginatedComponent<T> {
  pageNumber = signal(1);
  pageSize = signal(10);
  items = signal<T[]>([]);
  totalElements = signal(0);

  handlePageChange(event: any) {
    const page = Math.floor(event.first / event.rows) + 1;
    const size = event.rows;

    this.pageNumber.set(page);
    this.pageSize.set(size);
  }

  // Método abstrato que cada componente filho deve implementar
  abstract fetchData(): void;
}
