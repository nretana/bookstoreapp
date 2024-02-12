import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';

import Bootstrap from 'bootstrap';
import store from './store/store';

import { persistStore } from 'redux-persist';
import { PersistGate } from 'redux-persist/integration/react'

import './index.scss';
import './assets/scss/core/bootstrap.scss';

import App from './App';


export const persistor = persistStore(store);

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <Provider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <BrowserRouter>
          <App />
        </BrowserRouter>
      </PersistGate>
    </Provider>
  </React.StrictMode>
);