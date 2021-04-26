import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from "react-router-dom";

import App from './App';
import AuthContextProvider from './Context/authContext';
import ProductProdvider from './Context/productContext';
import CategoryProdvider from './Context/categoryContext';

import 'bootstrap/dist/css/bootstrap.min.css';

ReactDOM.render(
  <BrowserRouter>
    <AuthContextProvider>
      <ProductProdvider>
        <CategoryProdvider>
          <App />
        </CategoryProdvider>
      </ProductProdvider>
    </AuthContextProvider>
  </BrowserRouter>,
  document.getElementById('root')
);