import { createSlice } from '@reduxjs/toolkit';
import utils from '../../utils/utils';


const initialState = { textSearchQuery: '' }

const textSearchFilterSlice = createSlice({
    name: 'textSearchFilterState',
    initialState,
    reducers: {
        setTextSearch(state, action){
            const textSearch = action?.payload?.textSearch?.trim() ?? null;
            if(textSearch !== null){
                if(state.textSearchQuery === textSearch){
                    return;
                }

                state.textSearchQuery = textSearch;
                utils.updateSpecificQuerySearchParam('searchquery', textSearch);
            }
        },
        clearTextSearch(state){
            state.textSearchQuery = '';
            utils.updateSpecificQuerySearchParam('searchquery', '');
        },
        resetTextSearchState(state){
            return initialState
        }
    }
});

export const textSearchFilterActions = textSearchFilterSlice.actions;

export default textSearchFilterSlice;