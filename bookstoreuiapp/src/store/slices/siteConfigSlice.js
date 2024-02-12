import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    isDarkTheme: false,
    bodyClasses: ''
};

const siteConfigSlice = createSlice({
    name: 'siteConfigState',
    initialState,
    reducers: {
        setDarkTheme(state, action) {
            const isDarkTheme = action.payload ?? null;
            if(isDarkTheme !== null){
                state.isDarkTheme = isDarkTheme;
            }
        },
        setBodyClass(state, action){
            const bodyClass = action.payload ?? null;
            if(bodyClass){
                const currentBodyClass = state.bodyClasses;
                state.bodyClasses = currentBodyClass.concat(` ${bodyClass}`)
            }
        },
        removeBodyClass(state, action){
            const bodyClass = action.payload ?? null;
            if(bodyClass){
                const currentBodyClass = state.bodyClasses;
                state.bodyClasses = currentBodyClass.replace(bodyClass, '');
            }
        },
        setDarkThemeToggle(state){
            state.isDarkTheme = !state.isDarkTheme;
        }
    }
})

export const siteConfigActions = siteConfigSlice.actions;

export default siteConfigSlice;