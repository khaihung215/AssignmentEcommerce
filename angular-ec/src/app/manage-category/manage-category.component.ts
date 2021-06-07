import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manage-category',
  templateUrl: './manage-category.component.html',
  styleUrls: ['./manage-category.component.css'],
})
export class ManageCategoryComponent implements OnInit {
  product1 = 'assets/images/ao1.jpg';
  product2 = 'assets/images/ao2.jpg';

  constructor() {}

  ngOnInit(): void {}
}
