import { useState, useEffect } from 'react';
import { NavLink } from 'react-router-dom';

import Alert from 'react-bootstrap/Alert';
import Form from 'react-bootstrap/Form';
import Loading from '../UI/Loading';

import { useSignUpMutation } from '../../services/authApi';
import { validationPattern } from '../../utils/validationPattern';


const SignUp = (props) => {

    const [signUp, signUpResult] = useSignUpMutation({ fixedCacheKey: 'shared-signup-post' });

    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [isValidatedForm, setIsValidedForm] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    

    //reset the query state object on refresh/first load
    useEffect(() => signUpResult.reset(), []);

    const signUpRequest = async() => {
        const user = {
            firstName: firstName,
            lastname: lastName,
            email: email,
            password: password
        };
        
        try {
            await signUp(user).unwrap();
            props.onDisplayEmailVerificationView();

            setFirstName('');
            setLastName('')  ;
            setEmail('');
            setPassword('');
            setConfirmPassword('');
        }
        catch(error){
            setErrorMessage(error.errorMessage);
        }
    };

    const submitFormHandler = async (e) => {
        e.preventDefault();
        const form = e.currentTarget;

        if (!form.checkValidity()) {
          e.stopPropagation();
          setIsValidedForm(true);
          return;
        }

        signUpRequest();
    }

    return (<div className='row justify-content-center'>
        <div className='col'>
            <h1 className='display-4 text-center'>Create Your Account</h1>

            { signUpResult.isLoading && <Loading contentElementId='loading-state' /> }

            { signUpResult.isError &&
              <Alert variant='danger' className='mt-3'>
                <p className='mb-0'>{errorMessage}</p>
              </Alert> }

            <Form className='pt-4' noValidate validated={isValidatedForm} onSubmit={submitFormHandler}>
                <div className='mb-3'>
                    <label htmlFor='InputFirstName' className='form-label'>First Name</label>
                    <input id='InputFirstName' type='text' className='form-control' 
                                               value={firstName} 
                                               onChange={(e) =>setFirstName(e.target.value) } 
                                               required />
                    <div className='invalid-feedback'>
                        Please enter a valid first name.
                    </div>
                </div>
                <div className='mb-3'>
                    <label htmlFor='InputLastName' className='form-label'>Last Name</label>
                    <input id='InputLastName' type='text' className='form-control' 
                                              value={lastName} 
                                              onChange={(e) =>setLastName(e.target.value) } 
                                              required />
                    <div className='invalid-feedback'>
                        Please enter a valid last name.
                    </div>
                </div>
                <div className='mb-3'>
                    <label htmlFor='InputEmail' className='form-label'>Email</label>
                    <input id='InputEmail' type='email' className='form-control' 
                                           value={email} 
                                           onChange={(e) =>setEmail(e.target.value) } 
                                           required />
                    <div className='invalid-feedback'>
                        Please enter a valid email.
                    </div>
                </div>
                <div className='mb-3'>
                    <label htmlFor='InputPassword' className='form-label'>Password</label>
                    <input id='InputPassword' type='password' className='form-control' 
                                              value={password} 
                                              onChange={(e) =>setPassword(e.target.value) } 
                                              required 
                                              pattern={validationPattern.password} />
                    <div className='invalid-feedback'>
                        Please enter a valid password.
                    </div>
                </div>
                <div className='mb-4'>
                    <label htmlFor='InputConfirmPassword' className='form-label'>Confirm Password</label>
                    <input id='InputConfirmPassword' type='password' className='form-control' 
                                                     value={confirmPassword} 
                                                     onChange={(e) =>setConfirmPassword(e.target.value) }
                                                     required 
                                                     pattern={validationPattern.password} />
                    <div className='invalid-feedback'>
                        Please enter a valid password.
                    </div>
                </div> 
                <button className='btn btn-primary w-100'>Sign Up</button>
            </Form>
            <div className='mt-3'>
                <span>Already a member? </span>
                <NavLink to='/account/signin' className='link'>Sign In</NavLink>
            </div>
        </div>
    </div>)
}

export default SignUp;