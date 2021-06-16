import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Product } from 'src/models/product';
import { Review } from 'src/models/review';
import { ProductService } from 'src/services/productService';
import { ReviewService } from 'src/services/reviewService';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
  providers: [ProductService, ReviewService],
})
export class ProductDetailComponent implements OnInit {
  user = 'assets/images/user.png';

  product: Product;
  sameProducts: Product[];
  listReviews: Review[];

  constructor(
    private activatedRoute: ActivatedRoute,
    private productService: ProductService,
    private reviewService: ReviewService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((paramMap: ParamMap) => {
      this.getProductById(paramMap.get('id'));
      this.getSameProducts(paramMap.get('id'));
      this.getReviews(paramMap.get('id'));
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

  getReviews(id: String) {
    this.reviewService
      .getReviews(id)
      .subscribe((reviews) => (this.listReviews = reviews));
  }
}
