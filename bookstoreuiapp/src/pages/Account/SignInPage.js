import { useState } from 'react';
import { motion } from 'framer-motion'

import SignIn from '../../components/Account/SignIn';
import TwoStepVerification from '../../components/Account/TwoStepVerification';

const SignInPage = () => {
    const [isShowTwoStep, setIsShowTwoStep] = useState(false);

    const onDisplayTwoStepViewHandler = () => {
        setIsShowTwoStep(true);
    };

    return(
            <div className='row'>
                <div className='col-12'>
                { !isShowTwoStep ? 
                        <SignIn onDisplayTwoStepView={onDisplayTwoStepViewHandler} /> :
                        <motion.div initial={{ opacity: 0 }}
                                    animate={{ opacity: 1 }}
                                    transition={{ ease: [0.17, 0.67, 0.83, 0.67], duration: 1.2 }}>
                            <TwoStepVerification />
                        </motion.div>}
                </div>
            </div>)
}

export default SignInPage;