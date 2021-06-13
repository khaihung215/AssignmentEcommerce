import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Product } from 'src/models/product';
import { ProductService } from 'src/services/productService';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
  providers: [ProductService],
})
export class ProductDetailComponent implements OnInit {
  user = 'assets/images/user.jpg';

  product: Product;
  sameProducts: Product[];

  constructor(
    private activatedRoute: ActivatedRoute,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((paramMap: ParamMap) => {
      this.getProductById(paramMap.get('id'));
      this.getSameProducts(paramMap.get('id'));
    });
  }

  getProductById(id: String) {
    this.productService
      .getProductById(id)
      .subscribe((product) => (this.product = product));
  }

  getSameProducts(id: String) {
    this.productService
      .getSameProducts(id)
      .subscribe((products) => (this.sameProducts = products));
  }
}
