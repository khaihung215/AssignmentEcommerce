import React, { useState } from 'react';
import { Link } from 'react-router-dom';
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
              <NavLink>
                <Link className="text-secondary text-decoration-none" to="/product">Product</Link>
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink>
                <Link className="text-secondary text-decoration-none" to="/category">Category</Link>
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink>
                <Link className="text-secondary text-decoration-none" to="/user">User</Link>
              </NavLink>
            </NavItem>
          </Nav>
          <NavLink href="#">Logout</NavLink>
        </Collapse>
      </Navbar>
    </div>
  );
}

export default Header;