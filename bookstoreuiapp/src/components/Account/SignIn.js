import { useState, useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate, NavLink } from 'react-router-dom';

import Alert from 'react-bootstrap/Alert';
import Form from 'react-bootstrap/Form';
import Loading from '../UI/Loading';

import { useSignInMutation } from '../../services/authApi';
import { authActions } from '../../store/slices/authSlice';

const SignIn = (props) => {
    
    const [signIn, signInResult] = useSignInMutation({ fixedCacheKey: 'shared-signin-post' });
    
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [isRememberMe, setIsRememberMe] = useState(false);
    const [isValidForm, setIsValidForm] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');

    const dispatch = useDispatch();
    const navigate = useNavigate();

    //reset the query state object on refresh/first load
    useEffect(() =>  signInResult.reset(), []);

    const signInRequest = async () => {
        const user = {
            email: email,
            password: password,
            isRememberMe: true
        }

        try {
            const response = await signIn(user).unwrap();
            const data = response?.data ?? null;

            if(data !== null){
                if(data.isTwoStepEnabled){
                    props.onDisplayTwoStepView();
                } else {
                    dispatch(authActions.SignIn({ token: data.token }));
                    signInResult.reset();
                    navigate('/');
                }

                setEmail('');
                setPassword('');
                setIsRememberMe(false);
                setErrorMessage('');
            }
        }
        catch(error){
            setErrorMessage(error.errorMessage);
        }
    }

    const submitFormHandler = (e) => {
        e.preventDefault();
        const form = e.currentTarget;
        
        if (!form.checkValidity()) {
          e.stopPropagation();
          setIsValidForm(true);
          return;
        }

        signInRequest();
    };

    return (<div className='row justify-content-center'>
        <div className='col'>
            <h1 className='display-4 text-center'>Sign In Your Account</h1>

            { signInResult.isLoading && <Loading contentElementId='loading-state' /> }

            { (signInResult.error) && 
            <Alert variant='danger' className='mt-3'>
                <p className='mb-0'>{errorMessage}</p>
            </Alert> }
            <Form className='pt-4' noValidate validated={isValidForm} onSubmit={submitFormHandler}>
                <div className='mb-3'>
                    <label htmlFor='InputEmail' className='form-label' data-testid='email-label'>Email</label>
                    <div className='input-group has-validation'>
                        <input id='InputEmail' type='email' className='form-control' 
                                               value={email} 
                                               onChange={(e) => setEmail(e.target.value)} 
                                               required />
                        <div className='invalid-feedback'>
                            Please enter a valid user email.
                        </div>
                    </div>
                </div>
                <div className='mb-2'>
                    <label htmlFor='InputPassword' className='form-label' data-testid='password-label'>Password</label>
                    <input id='InputPassword' type='password' className='form-control' 
                                              value={password} 
                                              onChange={(e) => setPassword(e.target.value)} 
                                              required />
                    <div className='invalid-feedback'>
                        Please enter a valid password.
                    </div>
                </div>
                <div className='mb-4 text-end'>
                    <NavLink to='/account/forgotpassword'>Forgot Password?</NavLink>
                </div>
                <div className='mb-4'>
                    <input id='InputRememberMe' className='form-check-input' type='checkbox' 
                                                onChange={() => setIsRememberMe((prevState) => !prevState)} 
                                                defaultChecked={isRememberMe} />
                    <label className='form-check-label mx-1' htmlFor='InputRememberMe'>
                        Remember Me?
                    </label>
                </div>
                <button className='btn btn-primary w-100'>Sign In</button>
            </Form>
            <div className='mt-3'>
                <span>Not a member? </span>
                <NavLink to='/account/signup' className='link'>Sign Up</NavLink>
            </div>
        </div>
    </div>)
}

export default SignIn;