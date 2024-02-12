
const errorCode = Object.freeze({
    invalidEmail: "INVALID_EMAIL",
    invalidUser: "INVALID_USER",
    invalidToken: "INVALID_TOKEN",
    invalidTokenProvider: "INVALID_TOKEN_PROVIDER",
    invalidCode: "INVALID_CODE",
    emailNotConfirmed: "EMAIL_NOT_CONFIRMED",
    signUpUser: "SIGNUP_USER",
    userLockout: "USER_LOCKOUT"
})


export const statusCodeErrorMessage = (status = null, data = null) => {
    const errorList = data?.errors ?? [];
    const currentErrorCode = errorList.length > 0 ? errorList[0]?.code : '';

    switch(currentErrorCode){
        case errorCode.invalidEmail:
        case errorCode.invalidUser:
        case errorCode.signUpUser:
            return "Invalid username or password.";
        case errorCode.invalidToken:
            return "Your token is invalid or has expired."
        case errorCode.invalidCode:
            return "Your verification code is invalid."
        case errorCode.emailNotConfirmed:
            return "Email has not been confirmed."
        case errorCode.userLockout:
            return "Your account has been locked out. Please, reset your password to continue with the sign in process."
        case errorCode.invalidTokenProvider:
        default:
            return "There was a problem trying to process your request. Please try again later.";
    }

    //SIGNUP_USER
    //INVALID_EMAIL
    //INVALID_TOKEN
    //INVALID_USER
    //EMAIL_NOT_CONFIRMED
    //USER_LOCKOUT
    //INVALID_TOKEN_PROVIDER
    //INVALID_CODE
};
