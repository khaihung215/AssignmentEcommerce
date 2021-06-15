import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Category } from 'src/models/category';
import { CategoryService } from 'src/services/categoryService';
import { ProductService } from 'src/services/productService';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css'],
  providers: [CategoryService, ProductService],
})
export class EditProductComponent implements OnInit {
  editProductForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required]),
    categoryId: new FormControl('', [Validators.required]),
    images: new FormControl(''),
  });

  listCategories: Category[];
  id: any;

  constructor(
    private categoryService: CategoryService,
    private productService: ProductService,
    private activatedRoute: ActivatedRoute
  ) {}

  get f() {
    return this.editProductForm.controls;
  }

  ngOnInit(): void {
    this.categoryService
      .getCategories()
      .subscribe((categories) => (this.listCategories = categories));

    this.activatedRoute.paramMap.subscribe((paramMap: ParamMap) => {
      this.getProductById(paramMap.get('id'));
      this.id = paramMap.get('id');
    });
  }

  getProductById(id: String) {
    this.productService.getProductById(id).subscribe(
      (product) =>
        (this.editProductForm = new FormGroup({
          name: new FormControl(product.name, [Validators.required]),
          description: new FormControl(product.description, [
            Validators.required,
          ]),
          price: new FormControl(product.price, [Validators.required]),
          categoryId: new FormControl(product.categoryId, [
            Validators.required,
          ]),
          images: new FormControl(''),
        }))
    );
  }

  onSubmit() {
    var formData = new FormData();

    Object.keys(this.editProductForm.value).forEach((key) => {
      formData.append(key, this.editProductForm.value[key]);
    });

    this.productService.editProduct(this.id, formData);
  }

  onFileChange(event) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0] as File;
      this.editProductForm.get('images').setValue(file);
    }
  }
}
