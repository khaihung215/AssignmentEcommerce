import { backEnd_Url } from '../config';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from 'src/models/product';
import { map } from 'rxjs/operators';

const product_url = backEnd_Url + '/api/product';

@Injectable()
export class ProductService {
  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get(product_url).pipe(map((response: any) => response));
  }

  getProductById(id: String): Observable<Product> {
    return this.http
      .get(product_url + '/getproductbyid/' + id)
      .pipe(map((response: any) => response));
  }

  getSameProducts(id: String): Observable<Product[]> {
    return this.http
      .get(product_url + '/getproductsamecategory/' + id)
      .pipe(map((response: any) => response));
  }

  getHotProducts(): Observable<Product[]> {
    return this.http
      .get(product_url + '/gethotproduct')
      .pipe(map((response: any) => response));
  }

  getNewProducts(): Observable<Product[]> {
    return this.http
      .get(product_url + '/getnewproduct')
      .pipe(map((response: any) => response));
  }
}
