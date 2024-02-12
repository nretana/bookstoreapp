import { useState } from 'react';
import { motion } from 'framer-motion'

import SignUp from '../../components/Account/SignUp';
import EmailVerification from '../../components/Account/EmailVerification';

const SignUpPage = () => {
    const [isShowEmailVerification, setIsEmailVerification] = useState(false);

    const onDisplayEmailVerificationViewHandler = () => {
        setIsEmailVerification(true);
    };

    return(
        <div className='row'>
            <div className='col-12'>
                { !isShowEmailVerification ? 
                            <SignUp onDisplayEmailVerificationView={onDisplayEmailVerificationViewHandler} /> :
                            <motion.div initial={{ opacity: 0 }}
                                        animate={{ opacity: 1 }}
                                        transition={{ ease: [0.17, 0.67, 0.83, 0.67], duration: 1.2 }}> 
                                <EmailVerification />
                            </motion.div> }
            </div>
        </div>)
}

export default SignUpPage;