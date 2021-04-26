import React, { createContext, useState } from 'react';
import { signinRedirectCallback, signoutRedirectCallback } from '../Services/authService';
import RequestService from "../Services/request";

export const AuthContext = createContext({});

const AuthContextProvider = ({ children }) => {
    const [isAuth, setAuth] = useState(false);
    const [isAuthor, setAuthor] = useState(false);
    const [user, setUser] = useState(null);

    const signInRedirectCallback = () => {
        signinRedirectCallback()
            .then(res => {
                if (res.profile.role === 'admin') {
                    RequestService.setAuthentication(res.access_token);
                    setAuth(true);
                    setAuthor(true);
                    setUser(res);
                }
                else {
                    setAuth(true);
                    setAuthor(false);
                }
            })
            .catch(err => console.log(err));
    };

    const signOutRedirectCallback = () => {
        signoutRedirectCallback()
            .then(() => {
                setAuth(false);
                setAuthor(false);
                setUser(null);
            })
            .catch(err => console.log(err));
    };

    return (
        <AuthContext.Provider value={{
            isAuth,
            isAuthor,
            user,
            signInRedirectCallback,
            signOutRedirectCallback
        }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthContextProvider;