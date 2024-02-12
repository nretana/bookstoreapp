import { useState, useEffect, useRef } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';

import Alert from 'react-bootstrap/Alert';
import Form from 'react-bootstrap/Form';
import Loading from '../UI/Loading';

import { useSendTwoStepCodeMutation, useValidateTwoStepCodeMutation, useSignInMutation } from '../../services/authApi';
import { authActions } from '../../store/slices/authSlice';
import { validationPattern } from '../../utils/validationPattern';


const TwoStepVerification = () => {

    const [signIn, signInResult] = useSignInMutation({ fixedCacheKey: 'shared-signin-post' });
    const [twoStepVerification, twoStepVerificationResult] = useValidateTwoStepCodeMutation();
    const [sendTwoStepCode, sendTwoStepCodeResult] = useSendTwoStepCodeMutation();

    const [twoStepCode, setTwoStepCode] = useState('');
    const [isValidatedForm, setIsValidatedForm] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');

    const dispatch = useDispatch();
    const navigate = useNavigate();
    const isSkip = useRef(false);

    const signInResultData = signInResult.data ?? null;
    const twoStepVerificationResultData = twoStepVerificationResult.data ?? null;

    const sendTwoStepCodeRequest = () => {
        if(signInResult.isSuccess && signInResultData !== null){
            sendTwoStepCode({ 
                        email: signInResultData.data.email, 
                        isRememberMe: signInResultData.data.isRememberMe }).unwrap()
                                                                           .then(payload => setErrorMessage(''))
                                                                           .catch(error => setErrorMessage(error.errorMessage));
        }
    }

    const twoStepVerificationRequest = async () => {
        const user = {
            email: signInResultData.data.email,
            verificationCode: twoStepCode,
            isRememberMe: signInResultData.data.isRememberMe
        }

        try {
            await twoStepVerification(user).unwrap();

            setErrorMessage('');
            setTwoStepCode('');
        }
        catch(error){
            setErrorMessage(error.errorMessage);
        }
    }

    useEffect(()=> {
        if(isSkip.current === false){
            if(signInResult.isSuccess && signInResultData !== null){
                sendTwoStepCodeRequest();
            }
        }

        return () => isSkip.current = true;
    }, []);

    useEffect(() => {
        if(twoStepVerificationResult.isSuccess && twoStepVerificationResultData.data !== null){
            dispatch(authActions.SignIn({ token: twoStepVerificationResultData.data.token }));
            
            twoStepVerificationResult.reset();
            signInResult.reset();
            navigate('/');
        }

    }, [twoStepVerificationResult.isSuccess]);

    const submitFormHandler = (e) => {
        e.preventDefault();

        const form = e.currentTarget;
        if(!form.checkValidity()){
            e.stopPropagation();
            setIsValidatedForm(true);
            return;
        }

        twoStepVerificationRequest();
    };

    const resendTwoStepCodeHandler = (e) => {
        e.preventDefault();
        sendTwoStepCodeRequest();
    };

    return (<div className='row justify-content-center'>
        <div className='col'>
            <h1 className='display-4 text-center'>Two Step Verification</h1>

            { sendTwoStepCodeResult.isLoading && <Loading contentElementId='loading-state' />}
            
            { sendTwoStepCodeResult.isSuccess && 
            <Alert variant='info' className='mt-3'>
                <p className='mb-0'>A code has been sent to your email.</p>
            </Alert> }

            { (sendTwoStepCodeResult.isError || twoStepVerificationResult.isError) &&
            <Alert variant='danger' className='mt-3'>
                <p className='mb-0'>{errorMessage}</p>
            </Alert> }
            
            <Form className='pt-4' noValidate validated={isValidatedForm} onSubmit={submitFormHandler}>
                <div className='mb-3'>
                    <label htmlFor='InputTwoStepCode' className='form-label'>Verification Code</label>
                    <input id='InputTwoStepCode' type='text' className='form-control' 
                                        value={twoStepCode} 
                                        onChange={(e) => setTwoStepCode(e.target.value)} 
                                        required
                                        pattern={validationPattern.onlyNumbers} />
                    <div className='invalid-feedback'>
                        Please enter a valid code.
                    </div>
                </div>
                <div className='mb-4 text-end'>
                    <a href='#' className='link' onClick={resendTwoStepCodeHandler}>Resend Code</a>
                </div>
                <button className='btn btn-primary w-100'>Verify Code</button>
            </Form>
        </div>
    </div>)
}

export default TwoStepVerification;