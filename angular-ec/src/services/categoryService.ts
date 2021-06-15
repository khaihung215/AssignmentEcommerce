import { backEnd_Url } from '../config';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from 'src/models/category';
import { map } from 'rxjs/operators';
import { ToastService } from 'angular-toastify';

const category_url = backEnd_Url + '/api/categories';

@Injectable()
export class CategoryService {
  constructor(private http: HttpClient, private toastService: ToastService) {}

  getCategories(): Observable<Category[]> {
    return this.http.get(category_url).pipe(map((response: any) => response));
  }

  getCategoryById(id: String): Observable<Category> {
    return this.http
      .get(category_url + '/' + id)
      .pipe(map((response: any) => response));
  }

  addCategory(formData: any) {
    return this.http.post(category_url, formData).subscribe(
      (response) => this.toastService.success('Thêm danh mục thành công !'),
      (error) => this.toastService.error('Thêm danh mục thất bại !')
    );
  }

  editCategory(id: any, formData: any) {
    return this.http.put(category_url + '/' + id, formData).subscribe(
      (response) => this.toastService.success('Sửa danh mục thành công !'),
      (error) => this.toastService.error('Sửa danh mục thất bại !')
    );
  }

  deleteCategory(id: any) {
    return this.http.delete(category_url + '/' + id).subscribe(
      (response) => this.toastService.success('Xoá danh mục thành công !'),
      (error) => this.toastService.error('Xoá danh mục thất bại !')
    );
  }
}
