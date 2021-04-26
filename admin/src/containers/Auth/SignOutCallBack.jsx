import React, { useEffect, useContext } from "react";
import { useHistory } from "react-router-dom";
import { AuthContext } from '../../Context/authContext';

const SignOutCallBack = () => {
    const { signoutRedirectCallback } = useContext(AuthContext)

    const history = useHistory();

    useEffect(() => {
        signoutRedirectCallback();
        history.push("/");
    }, [history, signoutRedirectCallback]);

    return <div>Sign Out Redirecting...</div>;
};

export default SignOutCallBack;