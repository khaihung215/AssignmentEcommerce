import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/models/category';
import { CategoryService } from 'src/services/categoryService';
import { ProductService } from 'src/services/productService';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
  providers: [CategoryService, ProductService],
})
export class AddProductComponent implements OnInit {
  addProductForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required]),
    categoryId: new FormControl('', [Validators.required]),
    images: new FormControl(''),
  });

  listCategories: Category[];

  constructor(
    private categoryService: CategoryService,
    private productService: ProductService
  ) {}

  get f() {
    return this.addProductForm.controls;
  }

  ngOnInit(): void {
    this.categoryService
      .getCategories()
      .subscribe((categories) => (this.listCategories = categories));
  }

  onSubmit() {
    var formData = new FormData();

    Object.keys(this.addProductForm.value).forEach((key) => {
      formData.append(key, this.addProductForm.value[key]);
    });

    this.productService.addProduct(formData);
  }

  onFileChange(event) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0] as File;
      this.addProductForm.get('images').setValue(file);
    }
  }
}
