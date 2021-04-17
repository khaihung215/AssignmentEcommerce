import Layout from './containers/Layout';
import Home from './containers/Home/index.jsx'
import Product from './containers/Product';
import Category from './containers/Category';
import FormProduct from './containers/Product/FormProduct';
import FormCategory from './containers/Category/FormCategory';

import { BrowserRouter, Route } from 'react-router-dom';
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <Layout>

        <Route path="/" exact>
          <Home />
        </Route>

        <Route path="/product" >
          <Product />
        </Route>

        <Route path="/formproduct" >
          <FormProduct />
        </Route>

        <Route path="/category" >
          <Category />
        </Route>

        <Route path="/formcategory" >
          <FormCategory />
        </Route>

      </Layout>
    </BrowserRouter>
  );
}

export default App;