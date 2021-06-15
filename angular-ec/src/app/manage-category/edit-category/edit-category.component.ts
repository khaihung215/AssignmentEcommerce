import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { CategoryService } from 'src/services/categoryService';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css'],
  providers: [CategoryService],
})
export class EditCategoryComponent {
  id: any;

  editCategoryForm = new FormGroup({
    nameCategory: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    thumbnailImages: new FormControl(''),
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private categoryService: CategoryService
  ) {}

  get f() {
    return this.editCategoryForm.controls;
  }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((paramMap: ParamMap) => {
      this.getCategoryById(paramMap.get('id'));
      this.id = paramMap.get('id');
    });
  }

  getCategoryById(id: String) {
    this.categoryService.getCategoryById(id).subscribe(
      (category) =>
        (this.editCategoryForm = new FormGroup({
          nameCategory: new FormControl(category.nameCategory, [
            Validators.required,
          ]),
          description: new FormControl(category.description, [
            Validators.required,
          ]),
          thumbnailImages: new FormControl(''),
        }))
    );
  }

  onSubmit() {
    var formData = new FormData();

    Object.keys(this.editCategoryForm.value).forEach((key) => {
      formData.append(key, this.editCategoryForm.value[key]);
    });

    this.categoryService.editCategory(this.id, formData);
  }

  onFileChange(event) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0] as File;
      this.editCategoryForm.get('thumbnailImages').setValue(file);
    }
  }
}
