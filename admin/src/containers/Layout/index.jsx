import Header from '../../components/Header/header';
import Home from '../../components/Home/home';

function Layout({children}) {

  return (
      <>
        <Header></Header>
        <Home></Home>
        {children}
      </>
  );
}

export default Layout;