import React, { createContext, useState } from 'react';
import { signinRedirectCallback } from '../Services/authService';

export const AuthContext = createContext({});

const AuthContextProvider = ({ children }) => {
    const [isAuth, setAuth] = useState(false);
    const [user, setUser] = useState(null);

    const signInRedirectCallback = () => {
        signinRedirectCallback()
            .then(res => {
                const userRes = res;
                setAuth(true);
                setUser(userRes);
            })
            .catch(err => console.log(err));
    };

    return (
        <AuthContext.Provider value={{
            isAuth,
            user,
            setAuth,
            setUser,
            signInRedirectCallback
        }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthContextProvider;