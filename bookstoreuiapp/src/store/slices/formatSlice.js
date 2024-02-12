const { createSlice } = require('@reduxjs/toolkit');

const initialState = {
    formatList: []
}

const formatSlice = createSlice({
    name: 'formatState',
    initialState,
    reducers: {
        setFormatList(state, action){
            const formatList = action.payload ?? null;
            if(formatList !== null){
                state.formatList = formatList;
            }
        }
    }
});

export const formatActions = formatSlice.actions;
export default formatSlice;