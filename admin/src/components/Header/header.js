import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
} from 'reactstrap';

const Header = () => {
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => setIsOpen(!isOpen);

  return (
    <div>
      <Navbar color="light" light expand="md">
        <NavbarBrand href="/">Admin Unistore</NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            <NavItem>
              <Link className="text-secondary text-decoration-none mr-2" to="/product">Product</Link>
            </NavItem>
            <NavItem>
              <Link className="text-secondary text-decoration-none mr-2" to="/category">Category</Link>
            </NavItem>
            <NavItem>
              <Link className="text-secondary text-decoration-none mr-2" to="/user">User</Link>
            </NavItem>
          </Nav>
          <Link className="text-secondary text-decoration-none mr-2" to="/logout">Logout</Link>
        </Collapse>
      </Navbar>
    </div>
  );
}

export default Header;