import React, { useContext } from "react";
import { Route } from "react-router-dom";
import Login from "../containers/Auth/Login";

import { AuthContext } from '../Context/authContext';

export function PrivateRoute({ children, component: Component, ...rest }) {
    const { isAuth } = useContext(AuthContext);

    if (!isAuth) {
        Login();
    }

    return (
        <Route
            {...rest}
            render={({ location }) =>
                isAuth ? (
                    children
                ) : (
                    <Login />
                )
            }
        />
    )
}

export function PublicRoute({ children, ...rest }) {
    return (
        <Route {...rest}>
            {children}
        </Route>
    );
}