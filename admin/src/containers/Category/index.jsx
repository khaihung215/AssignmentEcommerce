import React from 'react';
import { Table, Button } from 'reactstrap';
import { PenFill, TrashFill, PlusCircleFill } from 'react-bootstrap-icons';
import { Link } from 'react-router-dom';

const Category = () => {
  return (
    <>
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
          <tr>
            <td>
              <img src="./mac.jpg" width="150px" height="150px"></img>
            </td>
            <td>Macbook</td>
            <td>Description of macbook</td>
            <td>
              <Button color="secondary" className="mr-2">
                <Link to="/formcategory">
                  <PenFill color="white" size={20} />
                </Link>
              </Button>
              <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
            </td>
          </tr>
          <tr>
            <td>
              <img src="./mac.jpg" width="150px" height="150px"></img>
            </td>
            <td>Hybird</td>
            <td>Description of hybird</td>
            <td>
              <Button color="secondary" className="mr-2">
                <Link to="/formcategory">
                  <PenFill color="white" size={20} />
                </Link>
              </Button>
              <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
            </td>
          </tr>
          <tr>
            <td>
              <img src="./mac.jpg" width="150px" height="150px"></img>
            </td>
            <td>Laptop</td>
            <td>Description of laptop</td>
            <td>
              <Button color="secondary" className="mr-2">
                <Link to="/formcategory">
                  <PenFill color="white" size={20} />
                </Link>
              </Button>
              <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
            </td>
          </tr>
        </tbody>
      </Table>
    </>
  );
}

export default Category;