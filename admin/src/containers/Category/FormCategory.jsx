import React from 'react';
import { InputGroup, InputGroupAddon, InputGroupText, Input, Button, Container } from 'reactstrap';
import * as Icon from 'react-bootstrap-icons';
import { Link } from 'react-router-dom';

const FormCategory = () => {
    return (
        <>
            <h2 className="text-center p-3">Form Category</h2>
            <div>
                <Container>
                    <InputGroup>
                        <InputGroupAddon addonType="prepend">
                            <InputGroupText><Icon.Spellcheck /></InputGroupText>
                        </InputGroupAddon>
                        <Input placeholder="Name" />
                    </InputGroup>
                    <br />
                    <InputGroup>
                        <InputGroupAddon addonType="prepend">
                            <InputGroupText><Icon.InfoCircle /></InputGroupText>
                        </InputGroupAddon>
                        <Input placeholder="Description" />
                    </InputGroup>
                    <br />
                    <InputGroup>
                        <Input type="file" />
                    </InputGroup>
                    <br />
                    <div className="text-center">
                        <Button color="secondary" className="mr-2">
                            <Link to="/category" className="text-decoration-none text-white">Close</Link>
                        </Button>{' '}
                        <Button color="success">Submit</Button>{' '}
                    </div>
                </Container>
            </div>
        </>
    );
}

export default FormCategory;