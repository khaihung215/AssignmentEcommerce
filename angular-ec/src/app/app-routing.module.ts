import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductPageComponent } from './product-page/product-page.component';

const routes: Routes = [
  { path: 'Home', component: HomeComponent },
  { path: 'Product', component: ProductPageComponent },
  { path: 'ProductDetail', component: ProductDetailComponent },
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: '**', component: NotfoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
