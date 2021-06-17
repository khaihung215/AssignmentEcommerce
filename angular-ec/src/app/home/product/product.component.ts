import { Component, OnInit } from '@angular/core';
import { CartCreateRequest } from 'src/models/cart';
import { Product } from 'src/models/product';
import { CartService } from 'src/services/cartService';
import { ProductService } from '../../../services/productService';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService, CartService],
})
export class ProductComponent implements OnInit {
  listHotProducts: Product[];
  listNewProducts: Product[];

  constructor(
    private productService: ProductService,
    private cartService: CartService
  ) {}

  ngOnInit() {
    this.getHotProducts();
    this.getNewProducts();
  }

  getHotProducts() {
    this.productService
      .getHotProducts()
      .subscribe((products) => (this.listHotProducts = products));
  }

  getNewProducts() {
    this.productService
      .getNewProducts()
      .subscribe((products) => (this.listNewProducts = products));
  }

  addToCart(id: any) {
    const formData: CartCreateRequest = {
      productId: id,
      quantity: 1,
    };

    this.cartService.addToCart(formData);
  }
}
