import { backEnd_Url } from '../config';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from 'src/models/category';
import { map } from 'rxjs/operators';

const category_url = backEnd_Url + '/api/categories';

@Injectable()
export class CategoryService {
  constructor(private http: HttpClient) {}

  getCategories(): Observable<Category[]> {
    return this.http.get(category_url).pipe(map((response: any) => response));
  }
}
