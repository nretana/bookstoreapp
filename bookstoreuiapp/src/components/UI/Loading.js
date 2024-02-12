import { Fragment } from 'react';
import { createPortal } from 'react-dom';

import styles from './Loading.module.scss';

const Loading = ({ customClasses, contentElementId }) => {

    const moreClasses =  customClasses !== undefined ? customClasses : '';
    const contentElemId = contentElementId !== undefined ? contentElementId : '';
    const overlayClass = contentElemId.trim().length > 0 ? '' : styles['overlay-window'];    
    const htmlContentElem =  document.getElementById(contentElemId);

    let loadingContent = <div className={`${styles.overlay} ${overlayClass} ${moreClasses}`}>
                            <div className='spinner-border align-self-center' role='status'>
                                <span className='visually-hidden'>Loading...</span>
                            </div>
                         </div>

    return(<Fragment>
            {(contentElemId.trim().length > 0 && htmlContentElem !== null) && createPortal(loadingContent, htmlContentElem)}
            {(contentElemId.trim().length === 0 && htmlContentElem == null) && loadingContent}
           </Fragment>);

};

export default Loading;