import { Component, OnInit } from '@angular/core';
import { Product } from 'src/models/product';
import { ProductService } from '../../../services/productService';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService],
})
export class ProductComponent implements OnInit {
  listHotProducts: Product[];
  listNewProducts: Product[];

  constructor(private productService: ProductService) {}

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
}
