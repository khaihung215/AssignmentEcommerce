import { backEnd_Url } from '../config';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Review } from 'src/models/review';
import { map } from 'rxjs/operators';
import { ToastService } from 'angular-toastify';

const review_url = backEnd_Url + '/api/reviews';

@Injectable()
export class ReviewService {
  constructor(private http: HttpClient, private toastService: ToastService) {}

  getReviews(id: String): Observable<Review[]> {
    return this.http
      .get(review_url + '/getreviews/' + id)
      .pipe(map((response: any) => response));
  }
}
