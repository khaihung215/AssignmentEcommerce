import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';

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
import { CartComponent } from './cart/cart.component';
import { ManageProductComponent } from './manage-product/manage-product.component';
import { ManageCategoryComponent } from './manage-category/manage-category.component';
import { AddProductComponent } from './manage-product/add-product/add-product.component';
import { EditProductComponent } from './manage-product/edit-product/edit-product.component';
import { AddCategoryComponent } from './manage-category/add-category/add-category.component';
import { EditCategoryComponent } from './manage-category/edit-category/edit-category.component';

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
    CartComponent,
    ManageProductComponent,
    ManageCategoryComponent,
    AddProductComponent,
    EditProductComponent,
    AddCategoryComponent,
    EditCategoryComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
