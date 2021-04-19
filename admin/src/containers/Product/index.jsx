import React, { useState, useContext } from 'react';
import { Table, Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { StarFill, PenFill, TrashFill, PlusCircleFill } from 'react-bootstrap-icons';
import { Link } from 'react-router-dom';

import { ProductContext } from '../../Context/productContext';

const Product = () => {
  const [modal, setModal] = useState(false);

  const toggle = () => setModal(!modal);

  const { productItems } = useContext(ProductContext);

  return (
    <>
      <h2 className="text-center p-3">Product</h2>
      <Button color="success" className="mb-2 ml-2"><PlusCircleFill color="white" size={20} className="mr-2" />
        <Link to="/formproduct" className="text-decoration-none text-white">Create new product</Link>
      </Button>
      <Table striped className="text-center">
        <thead>
          <tr>
            <th>Image</th>
            <th>Name</th>
            <th>Description</th>
            <th>Price</th>
            <th>Category</th>
            <th>Rating</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {
            productItems && productItems.map(product =>
              <tr>
                <td>
                  <img src={product.images} width="150px" height="150px"></img>
                </td>
                <td>{product.name}</td>
                <td>{product.description}</td>
                <td>{product.price}</td>
                <td>{product.nameCategory}</td>
                <td>
                  {Array.from(Array(product.rating), () => {
                    return <StarFill color="#ffdd59" size={20} />
                  })}
                </td>
                <td>
                  <Button color="secondary" className="mr-2">
                    <Link to="/formproduct">
                      <PenFill color="white" size={20} />
                    </Link>
                  </Button>
                  <Button color="danger" className="mr-2"><TrashFill color="white" size={20} onClick={toggle} /></Button>
                </td>
              </tr>
            )}
        </tbody>
      </Table>

      <div>
        <Modal isOpen={modal} toggle={toggle}>
          <ModalHeader toggle={toggle}>Delete</ModalHeader>
          <ModalBody>
            Do you want to delete this product ?
          </ModalBody>
          <ModalFooter>
            <Button color="secondary" onClick={toggle}>No</Button>{' '}
            <Button color="danger" onClick={toggle}>Yes</Button>{' '}
          </ModalFooter>
        </Modal>
      </div>
    </>
  );
}

export default Product;