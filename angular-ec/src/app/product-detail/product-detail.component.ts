import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Product } from 'src/models/product';
import { Review } from 'src/models/review';
import { ProductService } from 'src/services/productService';
import { ReviewService } from 'src/services/reviewService';
import { ToastService } from 'angular-toastify';
import { error } from 'protractor';
import { CartService } from 'src/services/cartService';
import { CartCreateRequest } from 'src/models/cart';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
  providers: [ProductService, ReviewService, CartService],
})
export class ProductDetailComponent implements OnInit {
  @ViewChild('closebutton') closebutton;

  user = 'assets/images/user.png';

  product: Product;
  sameProducts: Product[];
  listReviews: Review[];

  addReviewForm = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    content: new FormControl('', [Validators.required]),
    rating: new FormControl('', [Validators.required]),
    productId: new FormControl(''),
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private productService: ProductService,
    private reviewService: ReviewService,
    private cartService: CartService,
    private toastService: ToastService
  ) {}

  get f() {
    return this.addReviewForm.controls;
  }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((paramMap: ParamMap) => {
      this.getProductById(paramMap.get('id'));
      this.getSameProducts(paramMap.get('id'));
      this.getReviews(paramMap.get('id'));
    });
  }

  onSubmit() {
    var formData = new FormData();

    Object.keys(this.addReviewForm.value).forEach((key) => {
      formData.append(key, this.addReviewForm.value[key]);
    });

    this.reviewService
      .addReview(formData)
      .subscribe(
        (reviews) => (
          (this.listReviews = reviews),
          this.toastService.success('Thêm bình luận thành công !')
        )
      );

    this.closebutton.nativeElement.click();
  }

  getProductById(id: String) {
    this.productService.getProductById(id).subscribe(
      (product) => (
        this.addReviewForm.patchValue({
          productId: product.productId,
        }),
        (this.product = product)
      )
    );
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

  addToCart(id: any) {
    const formData: CartCreateRequest = {
      productId: id,
      quantity: 1,
    };

    this.cartService.addToCart(formData);
  }
}
