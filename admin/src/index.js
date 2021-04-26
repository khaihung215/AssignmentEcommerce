import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from "react-router-dom";

import App from './App';
import reportWebVitals from './reportWebVitals';
import AuthContextProvider from './Context/authContext';
import ProductProdvider from './Context/productContext';
import CategoryProdvider from './Context/categoryContext';

import './index.css';
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

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
