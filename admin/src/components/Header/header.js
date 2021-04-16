import React, { useState } from 'react';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
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
              <NavLink href="/product">Product</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/category">Category</NavLink>
            </NavItem>
          </Nav>
          <NavLink href="#">Logout</NavLink>
        </Collapse>
      </Navbar>
    </div>
  );
}

export default Header;