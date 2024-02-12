import { createSlice } from '@reduxjs/toolkit';

const initialState = { bookList: [],
    pagination: {
      totalCount: 0,
      totalPages: 0,
      currentPage: 0,
      hasPrevious: false,
      hasNext: false
    }
 }

const bookSlice = createSlice({
    name: 'bookState',
    initialState,
    reducers: {
        setBookList(state, action) {
            const bookList = action.payload?.bookList ?? null;
            const pagination = action.payload?.pagination ?? null;

            if(bookList !== null && pagination !== null) {
                state.bookList = [...bookList];
                state.pagination = {
                    totalCount: pagination.totalCount,
                    totalPages: pagination.totalPages,
                    currentPage: pagination.currentPage,
                    hasPrevious: pagination.hasPrevious,
                    hasNext: pagination.hasNext
                }
            }
        },
        resetBookState(state){
            return initialState;
        }
    }
});

export const bookActions = bookSlice.actions;

export default bookSlice;