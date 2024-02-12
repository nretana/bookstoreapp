import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    genreList: []
}

const genreSlice = createSlice({
    name: 'genreState',
    initialState,
    reducers: {
        setGenreList(state, action){
            const genreList = action.pyload ?? null;
            if(genreList !== null){
                state.genreList = genreList;
            }
        }
    }
});

export const genreActions = genreSlice.actions;
export default genreSlice;