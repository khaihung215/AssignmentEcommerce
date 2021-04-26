import React, { useContext } from "react";
import { Route } from "react-router-dom";

import Login from "../containers/Auth/Login";
import UnAuthorization from "../containers/Auth/UnAuthorization";

import { AuthContext } from '../Context/authContext';

export const PrivateRoute = ({ component: Component, ...rest }) => {
    const { isAuth, isAuthor } = useContext(AuthContext);

    if (!isAuth) return <Login />

    if (isAuth && !isAuthor) return <UnAuthorization />

    return (
        <Route {...rest} render={props => (
            isAuth && isAuthor ?
                <Component {...props} />
                : <Login />
        )} />
    );
};