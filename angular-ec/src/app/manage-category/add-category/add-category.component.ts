import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategoryService } from 'src/services/categoryService';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css'],
  providers: [CategoryService],
})
export class AddCategoryComponent {
  addCategoryForm = new FormGroup({
    nameCategory: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    thumbnailImages: new FormControl(''),
  });

  constructor(private categoryService: CategoryService) {}

  get f() {
    return this.addCategoryForm.controls;
  }

  onSubmit() {
    var formData = new FormData();

    Object.keys(this.addCategoryForm.value).forEach((key) => {
      formData.append(key, this.addCategoryForm.value[key]);
    });

    this.categoryService.addCategory(formData);
  }

  onFileChange(event) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0] as File;
      this.addCategoryForm.get('thumbnailImages').setValue(file);
    }
  }
}
