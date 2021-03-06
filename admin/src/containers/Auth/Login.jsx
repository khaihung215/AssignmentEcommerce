import React from "react";
import { Button } from "reactstrap";
import { signinRedirect } from "../../Services/authService";

export default function Login() {
    const handleClick = () => {
        signinRedirect();
    };
    return (
        <>
            <div class="text-center">
                <p>Please click the button to login !</p>
                <Button color="primary" onClick={handleClick}>
                    Login
                </Button>
            </div>
        </>
    );
}