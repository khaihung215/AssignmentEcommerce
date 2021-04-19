import React, { useState, useContext } from 'react';
import { Table, Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { PenFill, TrashFill, PlusCircleFill } from 'react-bootstrap-icons';
import { Link } from 'react-router-dom';

import CategoryContextProvider, { CategoryContext } from '../../Context/categoryContext';

const Category = () => {
  const [modal, setModal] = useState(false);

  const toggle = () => setModal(!modal);

  const { categoryItems } = useContext(CategoryContext);

  return (
    <CategoryContextProvider>
      <h2 className="text-center p-3">Category</h2>
      <Button color="success" className="mb-2 ml-2"><PlusCircleFill color="white" size={20} className="mr-2" />
        <Link to="/formcategory" className="text-decoration-none text-white">Create new category</Link>
      </Button>
      <Table striped className="text-center">
        <thead>
          <tr>
            <th>Image</th>
            <th>Name</th>
            <th>Description</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {
            categoryItems && categoryItems.map(category =>
              <tr key={category.categoryId}>
                <td>
                  <img src={category.images} alt={category.nameCategory} width="150px" height="150px"></img>
                </td>
                <td>{category.nameCategory}</td>
                <td>{category.description}</td>
                <td>
                  <Button color="secondary" className="mr-2">
                    <Link to="/formcategory">
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
            Do you want to delete this category ?
          </ModalBody>
          <ModalFooter>
            <Button color="secondary" onClick={toggle}>No</Button>{' '}
            <Button color="danger" onClick={toggle}>Yes</Button>{' '}
          </ModalFooter>
        </Modal>
      </div>
    </CategoryContextProvider>
  );
}

export default Category;