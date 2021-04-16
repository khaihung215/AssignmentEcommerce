import React from 'react';
import { Table, Button } from 'reactstrap';
import { StarFill, PenFill, TrashFill, PlusCircleFill } from 'react-bootstrap-icons';

const Product = () => {
  return (
    <>
      <h2 className="text-center p-3">Product</h2>
      <Button color="success" className="mb-2 ml-2"><PlusCircleFill color="white" size={20} className="mr-2"/>Create new product</Button>
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
          <tr>
            <td>
              <img src="./mac.jpg" width="150px" height="150px"></img>
            </td>
            <td>Macbook Pro 2021</td>
            <td>Description of macbook pro 2021</td>
            <td>59.990.000 VND</td>
            <td>Macbook</td>
            <td>
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
            </td>
            <td>
              <Button color="secondary" className="mr-2"><PenFill color="white" size={20} /></Button>
              <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
            </td>
          </tr>
          <tr>
            <td>
              <img src="./mac.jpg" width="150px" height="150px"></img>
            </td>
            <td>Macbook Pro 2021</td>
            <td>Description of macbook pro 2021</td>
            <td>59.990.000 VND</td>
            <td>Macbook</td>
            <td>
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
            </td>
            <td>
              <Button color="secondary" className="mr-2"><PenFill color="white" size={20} /></Button>
              <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
            </td>
          </tr>
          <tr>
            <td>
              <img src="./mac.jpg" width="150px" height="150px"></img>
            </td>
            <td>Macbook Pro 2021</td>
            <td>Description of macbook pro 2021</td>
            <td>59.990.000 VND</td>
            <td>Macbook</td>
            <td>
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
            </td>
            <td>
              <Button color="secondary" className="mr-2"><PenFill color="white" size={20} /></Button>
              <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
            </td>
          </tr>
        </tbody>
      </Table>
    </>
  );
}

export default Product;