import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {
  slide1 = 'assets/images/slideshow_1.jpg'
  slide2 = 'assets/images/slideshow_2.jpg'
  slide3 = 'assets/images/slideshow_3.jpg'


  constructor() { }

  ngOnInit(): void {
  }

}
