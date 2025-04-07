import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from '../../../../core/services/products.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { OrdersService } from '../../../../core/services/orders.service';

@Component({
  selector: 'app-buy-dialog',
  templateUrl: './buy-dialog.component.html',
  standalone: true,
  imports: [CommonModule,
  FormsModule, DialogModule],
})
export class BuyDialogComponent {
  @Input() visible: boolean = false;
  @Input() selectedProduct!: Product | null;
  @Input() quantity: number = 1;

  @Output() visibleChange = new EventEmitter<boolean>();
  @Output() confirm = new EventEmitter<number>();

  constructor(private buyService: OrdersService) {}

  confirmBuy() {
    this.buyService.buyProduct({
      productId: this.selectedProduct?.id || '',
      quantity: this.quantity
    }).subscribe({
      next: () => {
        alert('Sua compra foi registrada e está sendo processada. Você receberá uma atualização em breve!');
        this.closeDialog();
      },
      error: (err) => {
        console.error('Erro ao comprar:', err);
        alert('Erro ao realizar a compra.');
      }
    });
  }

  closeDialog() {
    this.visibleChange.emit(false);
  }

  // confirmBuy() {
  //   this.confirm.emit(this.quantity);
  //   this.closeDialog();
  // }
}