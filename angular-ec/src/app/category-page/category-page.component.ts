import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { CartCreateRequest } from 'src/models/cart';
import { Product } from 'src/models/product';
import { CartService } from 'src/services/cartService';
import { ProductService } from 'src/services/productService';

@Component({
  selector: 'app-category-page',
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.css'],
  providers: [ProductService, CartService],
})
export class CategoryPageComponent implements OnInit {
  listProducts: Product[];
  nameCategory: String;

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((paramMap: ParamMap) => {
      this.getProductsByCategory(paramMap.get('id'));
      this.nameCategory = paramMap.get('name');
    });
  }

  getProductsByCategory(id: String) {
    this.productService
      .getProductsByCategory(id)
      .subscribe((products) => (this.listProducts = products));
  }

  addToCart(id: any) {
    const formData: CartCreateRequest = {
      productId: id,
      quantity: 1,
    };

    this.cartService.addToCart(formData);
  }
}
