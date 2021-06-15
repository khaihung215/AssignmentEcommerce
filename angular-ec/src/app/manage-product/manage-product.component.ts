import { Component, OnInit } from '@angular/core';
import { Product } from 'src/models/product';
import { ProductService } from 'src/services/productService';

@Component({
  selector: 'app-manage-product',
  templateUrl: './manage-product.component.html',
  styleUrls: ['./manage-product.component.css'],
  providers: [ProductService],
})
export class ManageProductComponent implements OnInit {
  listProducts: Product[];
  productId: String = '';

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.productService
      .getProducts()
      .subscribe((products) => (this.listProducts = products));
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
