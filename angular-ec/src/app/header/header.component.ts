import { Component, OnInit } from '@angular/core';
import { Category } from 'src/models/category';
import { CategoryService } from 'src/services/categoryService';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [CategoryService],
})
export class HeaderComponent implements OnInit {
  logo = 'assets/images/logo.PNG';

  listCategories: Category[];

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.categoryService
      .getCategories()
      .subscribe((categories) => (this.listCategories = categories));
  }
}
