import { lazy, Suspense, useEffect } from 'react';
import { Navigate, Routes, Route } from 'react-router-dom';
import { useSelector } from 'react-redux';

import MainLayout from './components/UI/Layout/MainLayout';
import WideLayout from './components/UI/Layout/WideLayout';

import HomePage from './pages/HomePage';
import NotFoundPage from './pages/NotFoundPage';

import Loading from './components/UI/Loading';
import RequireAuth from './components/UI/RequireAuth';
import RequireNotAuth from './components/UI/RequireNotAuth';

import './App.scss';


const SearchPage = lazy(() => import('./pages/Books/SearchPage'));
const SignUpPage = lazy(()=> import('./pages/Account/SignUpPage'));
const SignInPage = lazy(()=> import('./pages/Account/SignInPage'));
const ForgotPasswordPage = lazy(()=> import('./pages/Account/ForgotPasswordPage'));


function App() {
  const isDarkTheme = useSelector(state => state.siteConfigState.isDarkTheme);

  useEffect(() => {
    let htmlElem = document.getElementsByTagName('html');
    if(htmlElem.length > 0){
        htmlElem[0].setAttribute('data-bs-theme', isDarkTheme ? 'dark' : 'light');
    }
  }, [isDarkTheme]);


  return (
    <div className="App">
      <Suspense fallback={<Loading />}>
      <Routes>
        <Route exact path="/" element={<MainLayout />}>
          <Route index element={<HomePage />} />
          <Route path='/books' element={<RequireAuth>
                                          <SearchPage />
                                        </RequireAuth>} />
          <Route path="*" element={<NotFoundPage />} />
        </Route>
        <Route exact path="/account" element={<WideLayout />}>
          <Route path="/account/signup" element={<RequireNotAuth>
                                                    <SignUpPage />
                                                  </RequireNotAuth>} />
          <Route path="/account/signin" element={<RequireNotAuth>
                                                   <SignInPage />
                                                 </RequireNotAuth>} />
          <Route path="/account/forgotpassword" element={<RequireNotAuth>
                                                          <ForgotPasswordPage />
                                                         </RequireNotAuth>} />
          <Route path="/account" element={<Navigate  to="/account/signin" replace={true}  />} />
        </Route>

      </Routes>
      </Suspense>
    </div>
  );
}

export default App;
 