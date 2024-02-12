import { createSlice } from "@reduxjs/toolkit"
import utils from '../../utils/utils';

const initialState = {
    pageNumber: 1,
    pageSize: 10,
    orderBy: 'title asc'
}

const paginationSlice = createSlice({
    name: 'paginationState',
    initialState,
    reducers: {
        setPageSize(state, action) {
            const pageSize = action.payload ?? 0;
            if(pageSize !== 0 && !isNaN(pageSize)){
                state.pageSize = parseInt(pageSize);
                utils.updateSpecificQuerySearchParam('pagesize', pageSize);
            }
        },
        setPageNumber(state, action) {
            const pageNumber = action.payload ?? 0;
            if(pageNumber !== 0 && !isNaN(pageNumber)){
                state.pageNumber = parseInt(pageNumber);
                utils.updateSpecificQuerySearchParam('pagenumber', pageNumber);
            }
        },
        setOrderBy(state, action) {
            const orderBy = action.payload ?? null;
            if(orderBy !== null){
                state.orderBy = orderBy;
                utils.updateSpecificQuerySearchParam('orderby', orderBy);
            }
        },
        increasePageNumber(state) {
            state.pageNumber = state.pageNumber + 1;
        },
        decreasePageNumber(state) {
            state.pageNumber = state.pageNumber - 1;
        },
        resetPaginationState(state){
            return initialState;
        }
    }
});

export const paginationActions = paginationSlice.actions;

export default paginationSlice;