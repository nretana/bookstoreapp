import { useState } from 'react';
import { motion } from 'framer-motion'
import ForgotPassword from '../../components/Account/ForgotPassword'
import PasswordReset from '../../components/Account/PasswordReset'

const ForgotPasswordPage = () => {

    const [isShowResetPassword, setIsShowResetPassword] = useState(false);

    const onResetPasswordViewHandler = () => {
        setIsShowResetPassword(true);
    };

    return(
        <div className='row'>
            <div className='col-12'>
            { !isShowResetPassword ? <ForgotPassword onDisplayResetPasswordView={onResetPasswordViewHandler} /> :
                                    <motion.div initial={{ opacity: 0 }}
                                                animate={{ opacity: 1 }}
                                                transition={{ ease: [0.17, 0.67, 0.83, 0.67], duration: 1.2 }}> 
                                        <PasswordReset />
                                    </motion.div> }
            </div>
        </div>
    )
}

export default ForgotPasswordPage;