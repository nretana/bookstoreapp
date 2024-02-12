import { createSlice } from '@reduxjs/toolkit';


const authSlice = createSlice({
    name: 'bookState',
    initialState: { isSignedIn: false },
    reducers: {
        SignIn(state, action) {
            var token = action.payload.token ?? null;
            if(token){
                localStorage.setItem('CID', token);
                state.isSignedIn = true;
            }
        },

        SignOut(state){
            localStorage.removeItem('CID');
            state.isSignedIn = false;
        }
    }
});


export const authActions = authSlice.actions;

export default authSlice;