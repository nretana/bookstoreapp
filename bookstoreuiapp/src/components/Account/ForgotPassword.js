import { useEffect, useState } from 'react';
import { useSendPasswordResetCodeMutation } from '../../services/authApi';

import Alert from 'react-bootstrap/Alert';
import Form from 'react-bootstrap/Form';


const ForgotPassword = (props) => {

    const [sendPasswordResetCode, sendPasswordResetCodeResult] = useSendPasswordResetCodeMutation({ fixedCacheKey: 'shared-password-reset-post' });
    const [email, setEmail] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const [isValidatedForm, setIsValidatedForm] = useState(false);

    useEffect(() =>  sendPasswordResetCodeResult.reset(), []);

    const submitFormHandler = async (e) => {
        e.preventDefault();

        const form = e.currentTarget;
        if(!form.checkValidity()){
            e.stopPropagation();
            setIsValidatedForm(true);
            return;
        }

        try {
            const sendEmailResult = await sendPasswordResetCode({ email }).unwrap();
            if(sendEmailResult.isSucceeded){
                props.onDisplayResetPasswordView();
            }
            
            setEmail('');
            setErrorMessage('');
        }
        catch(error){
            setErrorMessage(error.errorMessage);
        }
    };

    return (<div className='row justify-content-center'>
        <div className='col'>
            <h1 className='display-4 text-center'>Forgot Password</h1>

            { sendPasswordResetCodeResult.isError && 
            <Alert variant='danger' className='mt-3'>
                <p className='mb-0'>{errorMessage}</p>
            </Alert> }
            
            <Form className='pt-4' noValidate validated={isValidatedForm} onSubmit={submitFormHandler}>
                <div className='mb-3'>
                    <label htmlFor='InputEmail' className='form-label'>Email</label>
                    <input id='InputEmail' type='email' 
                                           className='form-control' 
                                           value={email} 
                                           onChange={(e) => setEmail(e.target.value)} 
                                           required />
                    <div className='invalid-feedback'>
                        Please enter a valid user email.
                    </div>
                </div>
                <button className='btn btn-primary w-100'>Send Email</button>
            </Form>
        </div>
    </div>)
}

export default ForgotPassword;