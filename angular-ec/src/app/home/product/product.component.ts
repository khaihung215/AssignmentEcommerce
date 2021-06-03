import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  product1 = 'assets/images/ao1.jpg';
  product2 = 'assets/images/ao2.jpg';

  constructor() {}

  ngOnInit(): void {}
}
