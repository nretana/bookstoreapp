import { Provider } from "react-redux"
import { render } from "@testing-library/react"

import { PersistGate } from 'redux-persist/integration/react'
import { persistStore as persistStoreSetup } from 'redux-persist';
import { combineReducers, configureStore } from '@reduxjs/toolkit';

//import persistor from '../../index';

import { store as setupStore } from '../../store/store';
import { persistedReducer, defaulMiddleware } from '../../store/store';
import { BrowserRouter } from "react-router-dom";

const store2 = configureStore({
    reducer: persistedReducer,
    devTools: process.env.NODE_ENV !== 'production',
    middleware: defaulMiddleware
});

export const renderWithProviders = (component, { 
                                                 store = store2,
                                                 persistStore = persistStoreSetup(store2),
                                                 ...renderOptions } = {}) => {
    const Wrapper = ({ children }) => {
        return <Provider store={store}>
                    <PersistGate loading={null} persistor={persistStore}>
                        <BrowserRouter>
                            {children}
                        </BrowserRouter>
                    </PersistGate>
                </Provider>
    }
    return { store, ...render(component, { wrapper: Wrapper, ...renderOptions }) }
} 