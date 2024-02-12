import { createSlice } from '@reduxjs/toolkit';
import utils from '../../utils/utils';

const initialState = {
    formatFilterList: [],
    formatsQuery: ''
};

const formatFilterSlice = createSlice({
    name: 'formatFilterState',
    initialState,
    reducers: {
        setFormatFilterList(state, action){
            const formatList = action?.payload.dataList ?? null;
            const formatQuery = action?.payload.formatQuery ?? '';
            const formatCheckedList = formatQuery.trim().length > 0 ? formatQuery.split(',') : [];

            if(formatList !== null){
                const formatFilterList = formatList.map((format, index) => ({ 
                                                                     formatId: `formatId${index}`, 
                                                                     name: format.name, 
                                                                     value: format.name, 
                                                                     isChecked: formatCheckedList.includes(format.name.toLowerCase()) }));
                state.formatFilterList = [...formatFilterList];
                state.formatsQuery = formatQuery;
                utils.updateSpecificQuerySearchParam('formats', formatQuery);
            }
        },
        addFormatToFilterList(state, action){
            const formatChecked = action?.payload.itemChecked ?? null;
            if(formatChecked !== null){
                const formatFilterList = state.formatFilterList;

                const index = formatFilterList.findIndex(item => item.value === formatChecked);
                formatFilterList[index].isChecked = true;
                const formatNamesChecked = formatFilterList.filter(item => item.isChecked)
                                                                 .map(item => item.value)
                                                                 .join(',')
                                                                 .toLowerCase();
                if(state.formatsQuery === formatNamesChecked){
                  return;
                }

                state.formatFilterList = [...formatFilterList];
                state.formatsQuery = formatNamesChecked;
                utils.updateSpecificQuerySearchParam('formats', formatNamesChecked);
            }
        },
        removeFormatFromFilterList(state, action) {
            const formatUnchecked = action?.payload.itemUnchecked ?? null;
            if(formatUnchecked !== null){
                const formatFilterList = state.formatFilterList;

                const index = formatFilterList.findIndex(item => item.value === formatUnchecked);
                formatFilterList[index].isChecked = false;
                const formatNamesChecked = formatFilterList.filter(item => item.isChecked)
                                                                 .map(item => item.value)
                                                                 .join(',')
                                                                 .toLowerCase();
                if(state.formatsQuery === formatNamesChecked){
                  return;
                }

                state.formatFilterList = [...formatFilterList];
                state.formatsQuery = formatNamesChecked;
                utils.updateSpecificQuerySearchParam('formats', formatNamesChecked);
            }
        },
        removeAllFormatFilters(state) {
            return initialState;
        },
        resetFormatState(state){
            return initialState;
        }
    }
});

export const formatFilterActions = formatFilterSlice.actions;
export default formatFilterSlice;