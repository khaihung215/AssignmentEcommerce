import React, { useState, useEffect } from 'react';
import { Table } from 'reactstrap';
import axios from "axios";

import { Backend_url } from "../../config";

const user_url = Backend_url + "/api/users";

const User = () => {
    const [userList, setUserList] = useState([]);

    useEffect(() => {
        (async () => {
            await axios.get(user_url)
                .then(response => setUserList(response.data))
                .catch((error) => {
                    console.log(error.response);
                    return [];
                });
        }
        )();
    }, []);

    return (
        <>
            <h2 className="text-center p-3">User</h2>
            <Table striped className="text-center">
                <thead>
                    <tr>
                        <th>Full Name</th>
                        <th>Phone</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        userList && userList.map(user =>
                            <tr key={user.id}>
                                <td>{user.fullName}</td>
                                <td>{user.phoneNumber}</td>
                                <td>{user.email}</td>
                            </tr>
                        )}
                </tbody>
            </Table>
        </>
    );
}

export default User;