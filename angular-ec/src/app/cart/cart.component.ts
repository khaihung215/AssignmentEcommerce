import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  product1 = 'assets/images/ao1.jpg';
  product2 = 'assets/images/ao2.jpg';

  constructor() {}

  ngOnInit(): void {}
}
