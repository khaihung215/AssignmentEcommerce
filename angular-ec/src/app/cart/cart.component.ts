import { Component, OnInit } from '@angular/core';
import { Cart } from 'src/models/cart';
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

  constructor(private cartService: CartService) {}

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
}
