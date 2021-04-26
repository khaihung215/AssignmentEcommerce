import React, { useEffect, useContext } from "react";
import { useHistory } from "react-router-dom";
import { AuthContext } from '../../Context/authContext';

const SignInCallBack = () => {
    const { signInRedirectCallback } = useContext(AuthContext)

    const history = useHistory();

    useEffect(() => {
        signInRedirectCallback();
        history.push("/");
    }, [history, signInRedirectCallback]);

    return <div>Sign In Redirecting...</div>;
};

export default SignInCallBack;