import React, { createContext, useState } from 'react';

export const AuthContext = createContext({});

const AuthContextProvider = ({ children }) => {
    const [isAuth, setAuth] = useState(false);
    const [user, setUser] = useState(null);

    return (
        <AuthContext.Provider value={{
            isAuth,
            user,
            setAuth,
            setUser
        }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthContextProvider;