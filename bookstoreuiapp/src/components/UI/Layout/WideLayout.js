import {  Fragment } from 'react';
import { Outlet } from 'react-router-dom';
import NavigationBar from '../NavigationBar';

import accountImg from '../../../assets/imgs/pexels-sasha-prasastika-3568258.jpg';

import styles from './WideLayout.module.scss';

const WideLayout = (props) => {
    return(
        <Fragment>
            <NavigationBar className="w-50" containerType='container-fluid' showNavbar="true" />
            <main>
                <div className={`container-fluid g-0 ${styles['account']}`}>
                    <div className='row g-0 h-100 mb-4'>
                        <div id='loading-state' className='col-12 px-3 col-lg-6 px-md-0 pb-4'>
                            <div className='row justify-content-center mt-6 g-0'>
                                <div className='col-10 col-sm-9 col-md-7 col-lg-8 col-xl-6'>
                                    <Outlet />
                                </div>
                            </div>
                        </div>
                        <div className='col-12 d-none col-md-6 d-lg-flex'>
                            <img  className={`img-fluid ${styles['img-account']}`} src={accountImg} alt='' />
                        </div>
                    </div>
                </div>
            </main>
        </Fragment>
    )
}

export default WideLayout;