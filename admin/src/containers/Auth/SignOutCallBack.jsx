import React, { useEffect } from "react";
import { signoutRedirectCallback } from "../../Services/authService";
import { useHistory } from "react-router-dom";

const SignOutCallBack = () => {
    const history = useHistory();
    useEffect(() => {
        async function signoutAsync() {
            await signoutRedirectCallback();
            history.push("/");
        }
        signoutAsync();
    }, [history]);

    return <div>Sign Out Redirecting...</div>;
};

export default SignOutCallBack;