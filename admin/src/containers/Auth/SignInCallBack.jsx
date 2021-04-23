import React, { useEffect, useContext } from "react";
import { signinRedirectCallback } from "../../Services/authService";
import { useHistory } from "react-router-dom";
import { AuthContext } from '../../Context/authContext';

const SignInCallBack = () => {
    const { setAuth, setUser, user } = useContext(AuthContext);

    const history = useHistory();

    useEffect(() => {
        signinRedirectCallback()
            .then(res => {
                const userRes = res.profile;
                setAuth(true);
                setUser(userRes);
                console.log(userRes);
                history.push("/");
            })
            .catch(err => console.log(err));
    }, [history]);

    return <div>Sign In Redirecting...</div>;
};

export default SignInCallBack;