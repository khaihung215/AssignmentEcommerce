import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { CarouselComponent } from './home/carousel/carousel.component';
import { CardComponent } from './home/card/card.component';
import { ProductComponent } from './home/product/product.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductPageComponent } from './product-page/product-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    CarouselComponent,
    CardComponent,
    ProductComponent,
    NotfoundComponent,
    ProductDetailComponent,
    ProductComponent,
    ProductPageComponent,
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
