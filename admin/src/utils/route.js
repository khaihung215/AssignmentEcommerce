import React, { useContext } from "react";
import { Route } from "react-router-dom";
import Login from "../containers/Auth/Login";

import { AuthContext } from '../Context/authContext';

export const PrivateRoute = ({ component: Component, ...rest }) => {
    const { isAuth } = useContext(AuthContext);

    return (
        <Route {...rest} render={props => (
            isAuth ?
                <Component {...props} />
                : <Login />
        )} />
    );
};

export function PublicRoute({ children, ...rest }) {
    return (
        <Route {...rest}>
            {children}
        </Route>
    );
}