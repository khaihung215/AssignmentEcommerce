export class Category {
  categoryId: string;
  nameCategory: string;
  description: string;
  images: string;

  constructor(
    categoryId: string,
    nameCategory: string,
    description: string,
    images: string
  ) {
    this.categoryId = categoryId;
    this.nameCategory = nameCategory;
    this.description = description;
    this.images = images;
  }
}
