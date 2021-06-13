import { Component, OnInit } from '@angular/core';
import { Product } from 'src/models/product';
import { ProductService } from 'src/services/productService';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css'],
  providers: [ProductService],
})
export class ProductPageComponent implements OnInit {
  listProducts: Product[];

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.productService
      .getProducts()
      .subscribe((products) => (this.listProducts = products));
  }
}
