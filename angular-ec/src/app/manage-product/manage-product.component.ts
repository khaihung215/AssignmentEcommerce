import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manage-product',
  templateUrl: './manage-product.component.html',
  styleUrls: ['./manage-product.component.css'],
})
export class ManageProductComponent implements OnInit {
  product1 = 'assets/images/ao1.jpg';
  product2 = 'assets/images/ao2.jpg';

  constructor() {}

  ngOnInit(): void {}
}
