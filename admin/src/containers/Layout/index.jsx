import Header from '../../components/Header/header';

function Layout({children}) {

  return (
      <>
        <Header></Header>
        {children}
      </>
  );
}

export default Layout;