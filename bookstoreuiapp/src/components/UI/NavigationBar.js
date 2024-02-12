import { Fragment } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Button, Nav, Navbar } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';

import { authActions } from '../../store/slices/authSlice';
import { siteConfigActions } from '../../store/slices/siteConfigSlice';

import { BsFillMoonFill, BsFillSunFill } from 'react-icons/bs';

import styles from './NavigationBar.module.scss';

const NavigationBar = (props) => {
    const dispatch = useDispatch();
    const isSignedIn = useSelector(state => state.authState.isSignedIn);
    const isDarkTheme = useSelector(state => state.siteConfigState.isDarkTheme);

    const isShowNavbar = props.showNavbar ?? true;
    const containerType = props.containerType ?? '';
    const customClasses = props.className ?? '';
    const navbarClasses = `${styles['navbar']} fixed-top py-3 ${customClasses}`;

    const changeThemeModeHandler = (e) => {
        e.preventDefault();
        dispatch(siteConfigActions.setDarkThemeToggle());
    };

    return(
        <Navbar expand='lg' className={navbarClasses}>
            <div className={containerType}>
                <NavLink className='navbar-brand' to='/'>Book</NavLink>
                { isShowNavbar === true  && 
                    <Fragment>
                        <Navbar.Toggle />
                        <Navbar.Collapse className='justify-content-end'>
                            <Nav className='align-items-lg-center'>
                                <NavLink className='nav-link' to='/'>Home</NavLink>
                                <NavLink className='nav-link' to='/books'>Books</NavLink>
                                {!isSignedIn &&
                                <Fragment>
                                    <NavLink className='nav-link' to='/account/signin'>Sign In</NavLink>
                                    <NavLink className='nav-link' to='/account/signup'>Sign Up</NavLink>
                                </Fragment> }

                                {isSignedIn &&
                                <NavLink className='nav-link' to='' onClick={() => dispatch(authActions.SignOut()) } >Sign Out</NavLink> }
                                <Nav.Item>
                                    <Button className={styles['btn-theme']} onClick={changeThemeModeHandler} aria-label={`switch to ${isDarkTheme ? 'light' : 'dark' } theme`}>
                                       { isDarkTheme ? <BsFillMoonFill /> : <BsFillSunFill /> }
                                    </Button>
                                </Nav.Item>
                            </Nav>

                            {/* <Navbar.Text>
                                Signed in as: 
                            </Navbar.Text> */}
                        </Navbar.Collapse>
                    </Fragment>
                }
            </div>
        </Navbar>)
}

export default NavigationBar;