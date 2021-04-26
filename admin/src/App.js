import React from 'react';
import Layout from './containers/Layout';
import Home from './containers/Home/index.jsx';
import Product from './containers/Product/index'
import Category from './containers/Category/index';
import User from './containers/User';
import FormProduct from './containers/Product/FormProduct';
import FormCategory from './containers/Category/FormCategory';
import SignInCallBack from './containers/Auth/SignInCallBack';
import SignOutCallBack from './containers/Auth/SignOutCallBack';

import ProductProdvider from './Context/productContext';
import CategoryProdvider from './Context/categoryContext';

import { BrowserRouter, Route } from 'react-router-dom';
import './App.css';
import { PrivateRoute } from './utils/route';

function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Route exact path="/" component={Home}>
        </Route>

        <ProductProdvider>
          <PrivateRoute exact path="/product" component={Product}>
          </PrivateRoute>

          <PrivateRoute exact path="/formproduct" component={FormProduct}>
          </PrivateRoute>
        </ProductProdvider>

        <CategoryProdvider>
          <PrivateRoute exact path="/category" component={Category}>
          </PrivateRoute>

          <PrivateRoute exact path="/formcategory" component={FormCategory}>
          </PrivateRoute>
        </CategoryProdvider>

        <PrivateRoute exact path="/user" component={User}>
        </PrivateRoute>

        <Route exact path="/signin-callback" component={SignInCallBack}>
        </Route>

        <Route exact path="/signout-callback" component={SignOutCallBack}>
        </Route>
      </Layout>
    </BrowserRouter>
  );
}

export default App;