import { useState, useEffect, useRef } from 'react';
import { useNavigate } from 'react-router-dom';

import Alert from 'react-bootstrap/Alert';
import Form from 'react-bootstrap/Form';
import Loading from '../UI/Loading';

import { useSendEmailConfirmationCodeMutation, useValidateEmailConfirmationCodeMutation, useSignUpMutation } from '../../services/authApi';
import { validationPattern } from '../../utils/validationPattern';

const EmailVerification = () => {

    const [signUp, signUpResult] = useSignUpMutation({ fixedCacheKey: 'shared-signup-post' });
    const [validateEmailVerificationCode, validateEmailVerificationCodeResult] = useValidateEmailConfirmationCodeMutation();
    const [sendEmailVerificationCode, sendEmailVerificationCodeResult] = useSendEmailConfirmationCodeMutation();

    const [emailVerificationCode, setEmailVerificationCode] = useState('');
    const [isValidatedForm, setIsValidedForm] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    
    const navigate = useNavigate();
    const isSkip = useRef(false);

    const signUpResultData = signUpResult.data ?? null;

    const sendEmailVerificationCodeRequest = () => {
        if(signUpResult.isSuccess && signUpResultData !== null){
            sendEmailVerificationCode({ 
                email: signUpResultData.data.userName }).unwrap()
                                                        .then(payload => setErrorMessage(''))
                                                        .catch(error => setErrorMessage(error.errorMessage));
        }
    }

    const validateTwoStepCodeRequest = async () => {
        const user = {
            email: signUpResultData.data.userName,
            verificationCode: emailVerificationCode
        }

        try {
            await validateEmailVerificationCode(user).unwrap();
            
            //reset sign-in step 1 and 2
            validateEmailVerificationCodeResult.reset();
            signUpResult.reset();
            setErrorMessage('');
            navigate('/account/signin');
        }
        catch(error){
            setErrorMessage(error.errorMessage);
        }
    }

    useEffect(()=> {
        if(isSkip.current === false){
            if(signUpResult.isSuccess){
                sendEmailVerificationCodeRequest();
            }
        }

        return () => isSkip.current = true;
    }, []);

    
    const submitFormHandler = (e) => {
        e.preventDefault();

        const form = e.currentTarget;
        if(form.checkValidity() === false){
            e.stopPropagation();
            setIsValidedForm(true);
            return;
        }

        validateTwoStepCodeRequest();
    };

    const resendEmailVerificationCodeHandler = (e) => {
        e.preventDefault();
        sendEmailVerificationCodeRequest();
    };

    return (<div className='row justify-content-center'>
        <div className='col'>
            <h1 className='display-4 text-center'>Sign Up Verification</h1>

            { sendEmailVerificationCodeResult.isLoading && <Loading contentElementId='loading-state' /> }
            
            {sendEmailVerificationCodeResult.isSuccess && 
            <Alert variant='info' className='mt-3'>
                <p className='mb-0'>A code has been sent to your email.</p>
            </Alert>  }

            { (sendEmailVerificationCodeResult.isError || 
               validateEmailVerificationCodeResult.isError) &&
               <Alert variant='danger' className='mt-3'>
                    <p className='mb-0'>{errorMessage}</p>
               </Alert> }
            
            <Form className='pt-4' noValidate validated={isValidatedForm} onSubmit={submitFormHandler}>
                <div className='mb-3'>
                    <label htmlFor='InputEmailVerificationCode' className='form-label'>Verification Code</label>
                    <input id='InputEmailVerificationCode' type='text' className='form-control' 
                                        value={emailVerificationCode} 
                                        onChange={(e) => setEmailVerificationCode(e.target.value)}
                                        required
                                        pattern={validationPattern.onlyNumbers} />
                    <div className='invalid-feedback'>
                        Please enter a valid password.
                    </div>
                </div>
                <div className='mb-4 text-end'>
                    <a href='#' className='link' onClick={resendEmailVerificationCodeHandler}>Resend Code</a>
                </div>
                <button className='btn btn-primary w-100'>Verify Code</button>
            </Form>
        </div>
    </div>)
}

export default EmailVerification;