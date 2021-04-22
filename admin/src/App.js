import Layout from './containers/Layout';
import Home from './containers/Home/index.jsx'
import Product from './containers/Product';
import Category from './containers/Category';
import User from './containers/User';
import FormProduct from './containers/Product/FormProduct';
import FormCategory from './containers/Category/FormCategory';
import ProductProdvider from './Context/productContext';
import CategoryProdvider from './Context/categoryContext';

import { BrowserRouter, Route } from 'react-router-dom';
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <Layout>

        <Route path="/" exact>
          <Home />
        </Route>

        <ProductProdvider>
          <Route path="/product" >
            <Product />
          </Route>

          <Route path="/formproduct" component={FormProduct}>
          </Route>
        </ProductProdvider>

        <CategoryProdvider>
          <Route path="/category" >
            <Category />
          </Route>

          <Route path="/formcategory" component={FormCategory}>
          </Route>
        </CategoryProdvider>

        <Route path="/user" >
          <User />
        </Route>

      </Layout>
    </BrowserRouter>
  );
}

export default App;