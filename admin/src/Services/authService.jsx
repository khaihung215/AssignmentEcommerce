import { UserManager } from "oidc-client";

import { Backend_url, Host_url } from "../config";

const config = {
    authority: Backend_url,
    client_id: "admin",
    redirect_uri: Host_url + '/signin-callback',
    post_logout_redirect_uri: Host_url + '/signout-callback',
    response_type: "id_token token",
    scope: "assignmentecommerce.api openid profile",
    automaticSilentRenew: true,
    includeIdTokenInSilentRenew: true,
};

const userManager = new UserManager(config);

export function signinRedirect() {
    return userManager.signinRedirect();
}

export function signinRedirectCallback() {
    return userManager.signinRedirectCallback();
}

export function signoutRedirect() {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect();
}

export function signoutRedirectCallback() {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
}

export default userManager;