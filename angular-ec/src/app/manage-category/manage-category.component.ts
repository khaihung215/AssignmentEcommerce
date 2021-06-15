import { Component, OnInit } from '@angular/core';
import { Category } from 'src/models/category';
import { CategoryService } from 'src/services/categoryService';

@Component({
  selector: 'app-manage-category',
  templateUrl: './manage-category.component.html',
  styleUrls: ['./manage-category.component.css'],
  providers: [CategoryService],
})
export class ManageCategoryComponent implements OnInit {
  listCategories: Category[];
  categoryId: String = '';

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.categoryService
      .getCategories()
      .subscribe((categories) => (this.listCategories = categories));
  }

  getCategoryId(id: String) {
    this.categoryId = id;
  }

  clearCategoryId() {
    this.categoryId = '';
  }

  deleteCategory() {
    this.categoryService.deleteCategory(this.categoryId);
    this.categoryId = '';

    setTimeout(() => {
      window.location.reload();
    }, 1500);
  }
}
