import { Component, OnInit } from '@angular/core';
import { Product, ProductPaged } from 'src/models/product';
import { ProductService } from 'src/services/productService';

@Component({
  selector: 'app-manage-product',
  templateUrl: './manage-product.component.html',
  styleUrls: ['./manage-product.component.css'],
  providers: [ProductService],
})
export class ManageProductComponent implements OnInit {
  listProducts: Product[];
  currentPage: number;
  totalItems: number;
  totalPages: number;
  productId: String = '';

  constructor(private productService: ProductService) {}

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

  getProductId(id: String) {
    this.productId = id;
  }

  clearProductId() {
    this.productId = '';
  }

  deleteProduct() {
    this.productService.deleteProduct(this.productId);
    this.productId = '';

    setTimeout(() => {
      window.location.reload();
    }, 1500);
  }
}
