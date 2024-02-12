import { Fragment } from 'react';
import { Outlet } from 'react-router-dom';
import NavigationBar from '../NavigationBar';

const MainLayout = () => {
    return(
        <Fragment>
            <NavigationBar containerType='container'/>
            <main>
                <div className='container-fluid px-0'>
                    <Outlet />
                </div>
            </main>
        </Fragment>
    )
}

export default MainLayout;