import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css'],
})
export class ProductPageComponent implements OnInit {
  product1 = 'assets/images/ao1.jpg';
  product2 = 'assets/images/ao2.jpg';

  constructor() {}

  ngOnInit(): void {}
}
