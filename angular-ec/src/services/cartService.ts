import { backEnd_Url } from '../config';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart, CartRespone } from 'src/models/cart';
import { map } from 'rxjs/operators';
import { ToastService } from 'angular-toastify';

const cart_url = backEnd_Url + '/api/carts';

@Injectable()
export class CartService {
  constructor(private http: HttpClient, private toastService: ToastService) {}

  getCartItems(): Observable<CartRespone> {
    return this.http
      .get(cart_url + '/getcartitems')
      .pipe(map((response: CartRespone) => response));
  }

  addToCart(formData: any) {
    return this.http.post(cart_url + '/postcartitems', formData).subscribe(
      (response) => this.toastService.success('Thêm vào giỏ hàng thành công !'),
      (error) => this.toastService.error('Thêm vào giỏ hàng thất bại !')
    );
  }

  updateCartItem(formData: any) {
    return this.http
      .put(cart_url + '/updatecartitems', formData)
      .pipe(map((response: CartRespone) => response));
  }
}
