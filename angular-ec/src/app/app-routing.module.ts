import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import { HomeComponent } from './home/home.component';
import { AddCategoryComponent } from './manage-category/add-category/add-category.component';
import { EditCategoryComponent } from './manage-category/edit-category/edit-category.component';
import { ManageCategoryComponent } from './manage-category/manage-category.component';
import { AddProductComponent } from './manage-product/add-product/add-product.component';
import { EditProductComponent } from './manage-product/edit-product/edit-product.component';
import { ManageProductComponent } from './manage-product/manage-product.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductPageComponent } from './product-page/product-page.component';

const routes: Routes = [
  { path: 'Home', component: HomeComponent },
  { path: 'Product', component: ProductPageComponent },
  { path: 'ProductDetail/:id', component: ProductDetailComponent },
  { path: 'Cart', component: CartComponent },
  { path: 'ManageProduct', component: ManageProductComponent },
  { path: 'ManageProduct/Add', component: AddProductComponent },
  { path: 'ManageProduct/Edit', component: EditProductComponent },
  { path: 'ManageCategory', component: ManageCategoryComponent },
  { path: 'ManageCategory/Add', component: AddCategoryComponent },
  { path: 'ManageCategory/Edit', component: EditCategoryComponent },
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: '**', component: NotfoundComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'enabled',
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
