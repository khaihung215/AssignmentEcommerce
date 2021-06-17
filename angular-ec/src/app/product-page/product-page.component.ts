import { Component, OnInit } from '@angular/core';
import { CartCreateRequest } from 'src/models/cart';
import { Product, ProductPaged, ProductRespone } from 'src/models/product';
import { CartService } from 'src/services/cartService';
import { ProductService } from 'src/services/productService';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css'],
  providers: [ProductService, CartService],
})
export class ProductPageComponent implements OnInit {
  listProducts: Product[];
  currentPage: number;
  totalItems: number;
  totalPages: number;

  constructor(
    private productService: ProductService,
    private cartService: CartService
  ) {}

  ngOnInit() {
    this.getProductsV2();
  }

  getProductsV2() {
    const formData: ProductPaged = {
      limit: 10,
      page: 1,
    };

    this.productService.getProductsV2(formData).subscribe((products) => {
      this.listProducts = products.items;
      this.totalItems = products.totalItems;
      this.totalPages = products.totalPages;
      this.currentPage = products.currentPage;
    });
  }

  handlePagination(page: any) {
    const formData: ProductPaged = {
      limit: 10,
      page: page,
    };

    this.productService.getProductsV2(formData).subscribe((products) => {
      this.listProducts = products.items;
      this.totalItems = products.totalItems;
      this.totalPages = products.totalPages;
      this.currentPage = products.currentPage;
    });

    window.scrollTo(0, 0);
  }

  addToCart(id: any) {
    const formData: CartCreateRequest = {
      productId: id,
      quantity: 1,
    };

    this.cartService.addToCart(formData);
  }
}
