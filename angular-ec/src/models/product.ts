export class Product {
  productId: string;
  name: string;
  description: string;
  price: number;
  images: string;
  categoryId: string;
  nameCategory: string;
  rating: number;

  constructor(
    productId: string,
    name: string,
    description: string,
    price: number,
    images: string,
    categoryId: string,
    nameCategory: string,
    rating: number
  ) {
    this.productId = productId;
    this.name = name;
    this.description = description;
    this.price = price;
    this.images = images;
    this.categoryId = categoryId;
    this.nameCategory = nameCategory;
    this.rating = rating;
  }
}
