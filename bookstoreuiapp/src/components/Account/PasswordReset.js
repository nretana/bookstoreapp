import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { usePasswordResetMutation, useSendPasswordResetCodeMutation } from '../../services/authApi';

import { validationPattern } from '../../utils/validationPattern';

import Alert from 'react-bootstrap/Alert';
import Form from 'react-bootstrap/Form';


const PasswordReset = () => {

    const [passwordReset, passwordResetResult] = usePasswordResetMutation();
    const [sendPasswordResetCode, sendPasswordResetCodeResult] = useSendPasswordResetCodeMutation({ fixedCacheKey: 'shared-password-reset-post' });
    const [password, setPassword] = useState('');
    const [verificationCode, setVerificationCode] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const [isValidatedForm, setIsValidatedForm] = useState(false);

    const navigation = useNavigate();

    const sendPasswordResetCodeResultData = sendPasswordResetCodeResult.data ?? null;

    const resendCodeHandler = (e) => {
        e.preventDefault();
        sendPasswordResetCode({ email: sendPasswordResetCodeResultData.data.email }).unwrap()
                                                                                .then(payload => setErrorMessage(''))
                                                                                .catch(error => setErrorMessage(error.errorMessage));
    }

    const submitFormHandler = async (e) => {
        e.preventDefault();

        const form = e.currentTarget;
        if(!form.checkValidity()){
            e.stopPropagation();
            setIsValidatedForm(true);
            return;
        }

        try {
            const user = {
                email: sendPasswordResetCodeResultData.data.email,
                newPassword: password,
                verificationCode: verificationCode
            };

            const passwordResetResultData = await passwordReset(user).unwrap();
            if(passwordResetResultData.isSucceeded){
                sendPasswordResetCodeResult.reset();
                passwordResetResult.reset();
                navigation('/account/signin');
            }

            setPassword('');
            setVerificationCode('');
            setErrorMessage('');
        }
        catch(error){
            setErrorMessage(error.errorMessage);
        }
    };

    return (<div className='row justify-content-center'>
        <div className='col'>
            <h1 className='display-4 text-center'>Reset Your Password</h1>

            {sendPasswordResetCodeResult.isSuccess && 
            <Alert variant='info' className='mt-3'>
                <p className='mb-0'>A code has been sent to your email.</p>
            </Alert>  }
            
            { (sendPasswordResetCodeResult.isError || 
               passwordResetResult.isError) &&
               <Alert variant='danger' className='mt-3'>
                    <p className='mb-0'>{errorMessage}</p>
               </Alert> }
            
            <Form className='pt-4' noValidate validated={isValidatedForm} onSubmit={submitFormHandler}>
                <div className='mb-3'>
                    <label htmlFor='InputPassword' className='form-label'>Password</label>
                    <input id='InputPassword' type='password'
                                              className='form-control'
                                              value={password}
                                              onChange={(e)=>setPassword(e.target.value)}
                                              required
                                              pattern={validationPattern.password} />
                    <div className='invalid-feedback'>
                        Please enter a valid password.
                    </div>
                </div>
                <div className='mb-4'>
                    <label htmlFor='InputVerificationCode' className='form-label'>Verification Code</label>
                    <input id='InputVerificationCode' type='text' 
                                                      className='form-control' 
                                                      value={verificationCode} 
                                                      onChange={(e)=>setVerificationCode(e.target.value)}
                                                      required
                                                      pattern={validationPattern.onlyNumbers} />
                    <div className='invalid-feedback'>
                        Please enter a valid code.
                    </div>
                </div>
                <div className='mb-4 text-end'>
                    <a href='#' className='link' onClick={resendCodeHandler}>Resend code</a>
                </div>
                <button className='btn btn-primary w-100'>Reset Password</button>
            </Form>
        </div>
    </div>)
}

export default PasswordReset;