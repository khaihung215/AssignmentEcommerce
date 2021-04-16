import Layout from './containers/Layout';
import Home from './containers/Home/index.jsx'
import Product from './containers/Product';

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

      </Layout>
    </BrowserRouter>
  );
}

export default App;