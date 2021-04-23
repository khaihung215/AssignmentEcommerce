import React from 'react';
import Layout from './containers/Layout';
import Home from './containers/Home/index.jsx'
import Product from './containers/Product';
import Category from './containers/Category';
import User from './containers/User';
import FormProduct from './containers/Product/FormProduct';
import FormCategory from './containers/Category/FormCategory';
import ProductProdvider from './Context/productContext';
import CategoryProdvider from './Context/categoryContext';
import SignInCallBack from './containers/Auth/SignInCallBack';
import SignOutCallBack from './containers/Auth/SignOutCallBack';

import { BrowserRouter, Switch } from 'react-router-dom';
import './App.css';
import { PrivateRoute, PublicRoute } from './utils/route';

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Layout>

          <PublicRoute path="/" exact component={Home}>
          </PublicRoute>

          <ProductProdvider>
            <PrivateRoute exact path="/product" component={Product}>
            </PrivateRoute>

            <PrivateRoute path="/formproduct" component={FormProduct}>
            </PrivateRoute>
          </ProductProdvider>

          <CategoryProdvider>
            <PrivateRoute exact path="/category" component={Category}>
            </PrivateRoute>

            <PrivateRoute path="/formcategory" component={FormCategory}>
            </PrivateRoute>
          </CategoryProdvider>

          <PrivateRoute path="/user" component={User}>
          </PrivateRoute>

          <PublicRoute path="/signin-callback" component={SignInCallBack}>
          </PublicRoute>

          <PublicRoute path="/signout-callback" component={SignOutCallBack}>
          </PublicRoute>

        </Layout>
      </Switch>
    </BrowserRouter>
  );
}

export default App;