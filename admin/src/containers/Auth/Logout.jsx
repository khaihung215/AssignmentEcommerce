import React from "react";
import { Button } from "reactstrap";
import { signoutRedirect } from "../../Services/authService";

export default function Logout() {
    const handleClick = () => {
        signoutRedirect();
    };
    return (
        <>
            <div class="text-center">
                <p>Please click the button to logout !</p>
                <Button color="primary" onClick={handleClick}>
                    Logout
                </Button>
            </div>
        </>
    );
}