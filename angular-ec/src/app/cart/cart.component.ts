import { identifierModuleUrl } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ToastService } from 'angular-toastify';
import { Cart, CartUpdateRequest } from 'src/models/cart';
import { CartService } from 'src/services/cartService';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
  providers: [CartService],
})
export class CartComponent implements OnInit {
  listCartItems: Cart[];
  totalPrice: number;
  totalItems: number;

  constructor(
    private cartService: CartService,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {
    this.getCartItems();
  }

  getCartItems() {
    this.cartService
      .getCartItems()
      .subscribe(
        (cartItems) => (
          (this.listCartItems = cartItems.items),
          (this.totalPrice = cartItems.totalPrice),
          (this.totalItems = cartItems.totalItems)
        )
      );
  }

  buttonMinus(id: any) {
    const formData: CartUpdateRequest = {
      cartDetailId: id,
      quantity: -1,
    };

    this.cartService.updateCartItem(formData).subscribe((cartItems) => {
      this.listCartItems = cartItems.items;
      this.totalPrice = cartItems.totalPrice;
      this.totalItems = cartItems.totalItems;
    });

    this.toastService.success('Cập nhật thành công !');
  }

  buttonPlus(id: any) {
    const formData: CartUpdateRequest = {
      cartDetailId: id,
      quantity: 1,
    };

    this.cartService.updateCartItem(formData).subscribe((cartItems) => {
      this.listCartItems = cartItems.items;
      this.totalPrice = cartItems.totalPrice;
      this.totalItems = cartItems.totalItems;
    });

    this.toastService.success('Cập nhật thành công !');
  }
}
