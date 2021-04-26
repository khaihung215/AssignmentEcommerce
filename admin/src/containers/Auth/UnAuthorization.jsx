import React from "react";
import { Button } from "reactstrap";
import { signoutRedirect } from "../../Services/authService";

export default function UnAuthorization() {
    const handleClick = () => {
        signoutRedirect();
    };

    return (
        <>
            <div class="text-center">
                <p>Your account is not authorized !</p>
                <Button color="primary" onClick={handleClick}>
                    Logout
                </Button>
            </div>
        </>
    );
}