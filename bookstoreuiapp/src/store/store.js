import { combineReducers, configureStore } from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/query'
import storage from 'redux-persist/lib/storage';
import autoMergeLevel2 from 'redux-persist/es/stateReconciler/autoMergeLevel2';
import { persistReducer, FLUSH,
    REHYDRATE,
    PAUSE,
    PERSIST,
    PURGE,
    REGISTER } from 'redux-persist';

import { authApi } from '../services/authApi';
import { bookApi } from '../services/bookApi';
import { formatApi } from '../services/formatApi';
import { genreApi } from '../services/genreApi';
import { authorApi } from '../services/authorApi';
import authSlice from './slices/authSlice';
import bookSlice from './slices/bookSlice';
//import formatSlice from './slices/formatSlice';
import paginationSlice from './slices/paginationSlice';
import textSearchFilterSlice from './slices/textSearchFilterSlice';
import formatFilterSlice from './slices/formatFilterSlice';
import genreFilterSlice from './slices/genreFilterSlice';
import siteConfigSlice from './slices/siteConfigSlice';

const persistConfig = {
    key: 'root',
    version: 1,
    storage,
    stateReconciler: autoMergeLevel2,
    blacklist: [bookApi.reducerPath,
                formatApi.reducerPath,
                genreApi.reducerPath,
                authorApi.reducerPath,
                //siteConfigSlice.name,
                bookSlice.name,
                formatFilterSlice.name,
                genreFilterSlice.name,
                paginationSlice.name,
                textSearchFilterSlice.name] //genreApi.reducerPath
}

const reducers = combineReducers({
    [authApi.reducerPath]: authApi.reducer,
    [bookApi.reducerPath]: bookApi.reducer,
    [genreApi.reducerPath]: genreApi.reducer,
    [formatApi.reducerPath]: formatApi.reducer,
    [authorApi.reducerPath]: authorApi.reducer,
    siteConfigState: siteConfigSlice.reducer,
    authState: authSlice.reducer,
    bookState: bookSlice.reducer,
    //formatState: formatSlice.reducer,
    paginationState: paginationSlice.reducer,
    genreFilterState: genreFilterSlice.reducer,
    formatFilterState: formatFilterSlice.reducer,
    textSearchFilterState: textSearchFilterSlice.reducer
});

export const persistedReducer = persistReducer(persistConfig, reducers);

export const defaulMiddleware = (getDefaultMiddleware) => getDefaultMiddleware({
                                                                serializableCheck: {
                                                                    ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER]
                                                                }
                                                            }).concat(authApi.middleware, 
                                                                        bookApi.middleware,
                                                                        formatApi.middleware, 
                                                                        genreApi.middleware,
                                                                        authorApi.middleware)

const store = configureStore({
    reducer: persistedReducer,
    devTools: process.env.NODE_ENV !== 'production',
    middleware: defaulMiddleware
})

//setupListeners(store.dispatch)

export default store;