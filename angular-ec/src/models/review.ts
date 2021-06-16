export class Review {
  reviewId: string;
  content: string;
  rating: number;
  productId: string;
  userId: string;
  userName: string;
  dateReview: Date;

  constructor(
    reviewId: string,
    content: string,
    rating: number,
    productId: string,
    userId: string,
    userName: string,
    dateReview: Date
  ) {
    this.reviewId = reviewId;
    this.content = content;
    this.rating = rating;
    this.productId = productId;
    this.userId = userId;
    this.userName = userName;
    this.dateReview = dateReview;
  }
}
