import React, { useContext } from 'react';
import { Table, Button } from 'reactstrap';
import { PenFill, TrashFill, PlusCircleFill } from 'react-bootstrap-icons';
import { Link } from 'react-router-dom';

import { CategoryContext } from '../../Context/categoryContext';

const Category = () => {
  const { categoryItems } = useContext(CategoryContext);

  return (
    <>
      <h2 className="text-center p-3">Category</h2>
      <Button color="success" className="mb-2 ml-2"><PlusCircleFill color="white" size={20} className="mr-2" />
        <Link to={{
          pathname: '/formcategory',
          categoryId: '',
          category: {
            nameCategory: '',
            description: '',
            images: null,
          }
        }} className="text-decoration-none text-white">Create new category</Link>
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
                    <Link to={{
                      pathname: '/formcategory',
                      categoryId: category.categoryId,
                      category: {
                        nameCategory: category.nameCategory,
                        description: category.description,
                        images: null,
                      }
                    }}>
                      <PenFill color="white" size={20} />
                    </Link>
                  </Button>
                  <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
                </td>
              </tr>
            )}
        </tbody>
      </Table>
    </>
  );
}

export default Category;