import React from 'react';
import Header from './containers/Header/index';
import Home from './containers/Home/index';
import Product from './containers/Product/index'
import Category from './containers/Category/index';
import User from './containers/User';
import FormProduct from './containers/Product/FormProduct';
import FormCategory from './containers/Category/FormCategory';
import SignInCallBack from './containers/Auth/SignInCallBack';
import SignOutCallBack from './containers/Auth/SignOutCallBack';

import { Route, Switch } from 'react-router-dom';
import { PrivateRoute } from './utils/route';
import './App.css';

function App() {
  return (
    <div>
      <Header />
      <Switch>
        <Route exact path="/" component={Home}>
        </Route>

        <PrivateRoute exact path="/product" component={Product}>
        </PrivateRoute>

        <PrivateRoute exact path="/formproduct" component={FormProduct}>
        </PrivateRoute>

        <PrivateRoute exact path="/category" component={Category}>
        </PrivateRoute>

        <PrivateRoute exact path="/formcategory" component={FormCategory}>
        </PrivateRoute>

        <PrivateRoute exact path="/user" component={User}>
        </PrivateRoute>

        <Route exact path="/signin-callback" component={SignInCallBack}>
        </Route>

        <Route exact path="/signout-callback" component={SignOutCallBack}>
        </Route>
      </Switch>
    </div>
  );
}

export default App;