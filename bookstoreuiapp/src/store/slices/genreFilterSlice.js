import { createSlice } from '@reduxjs/toolkit';
import utils from '../../utils/utils';

const initialState = { 
    genreFilterList: [],
    genresQuery: ''
  }

const genreFilterSlice = createSlice({
    name: 'genreFilterState',
    initialState,
    reducers: {
        setGenreFilterList(state, action){
            const genreList = action?.payload.dataList ?? null;
            const genreQuery = action?.payload.genreQuery ?? '';
            
            const genreCheckedList = genreQuery.trim().length > 0 ? genreQuery.toLowerCase().split(',') : [];

            if(genreList !== null){
                const genreFilterList = genreList.map((genre, index) => ({ 
                                                                     genreId: `genreId${index}`, 
                                                                     name: genre.name, 
                                                                     value: genre.name, 
                                                                     isChecked: genreCheckedList.includes(genre.name.toLowerCase()) }));

                state.genreFilterList = [...genreFilterList];
                state.genresQuery = genreQuery;
                utils.updateSpecificQuerySearchParam('genres', genreQuery);
            }
        },
        addGenreToFilterList(state, action) {
            const genreChecked = action.payload.itemChecked ?? null;
            if(genreChecked !== null){
                const genreFilterList = state.genreFilterList;

                const index = genreFilterList.findIndex(item => item.value === genreChecked);
                genreFilterList[index].isChecked = true;
                const genreNamesChecked = genreFilterList.filter(item => item.isChecked)
                                                               .map(item => item.value)
                                                               .join(',')
                                                               .toLocaleLowerCase();
                if(state.genresQuery === genreNamesChecked){
                    return;
                }

                state.formatFilterList = [...genreFilterList];
                state.genresQuery = genreNamesChecked;
                utils.updateSpecificQuerySearchParam('genres', genreNamesChecked);
            }
        },
        removeGenreFromFilterList(state, action) {
            const genreUnchecked = action?.payload.itemUnchecked ?? null;
            if(genreUnchecked !== null){
                const genreFilterList = state.genreFilterList;

                const index = genreFilterList.findIndex(item => item.value === genreUnchecked);
                genreFilterList[index].isChecked = false;
                const genreNamesChecked = genreFilterList.filter(item => item.isChecked)
                                                                        .map(item => item.value).join(',').toLocaleLowerCase();
                if(state.genresQuery === genreNamesChecked){
                  return;
                }

                state.genreFilterList = [...genreFilterList];
                state.genresQuery = genreNamesChecked;
                utils.updateSpecificQuerySearchParam('genres', genreNamesChecked);
            }
        },
        removeAllGenreFilters(state) {
            return initialState;
        },
        resetGenreState(state){
            return initialState;
        }
    }
});

export const genreFilterActions = genreFilterSlice.actions;

export default genreFilterSlice;