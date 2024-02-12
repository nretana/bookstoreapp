import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useSearchParams } from 'react-router-dom';

import { useGetAllFormatsQuery } from '../../../services/formatApi';
import { formatFilterActions } from '../../../store/slices/formatFilterSlice';


const FormatFilter = () => {

    const { data, isSuccess, isError, isFetching } = useGetAllFormatsQuery();
    const dispatch = useDispatch();
    const [querySearchParams, setQuerySearchParams] = useSearchParams();

    const formatFilterList = useSelector(state => state.formatFilterState.formatFilterList) ?? [];
    const formatQueryString = querySearchParams.has('formats') ? querySearchParams.get('formats') : '';

    useEffect(() => {
        if(isSuccess && data){
            dispatch(formatFilterActions.setFormatFilterList({ dataList: data.formatList, formatQuery: formatQueryString }));
        }
    }, [isSuccess, isError, data, dispatch]);

    const changeCheckBoxHandler = (e) => {
        const value = e.target.value;
        const isChecked = e.target.checked;
        isChecked ? dispatch(formatFilterActions.addFormatToFilterList({ itemChecked: value })) : 
                    dispatch(formatFilterActions.removeFormatFromFilterList({ itemUnchecked: value }));
    };

    return(<div className='mt-3'>
                <div>
                    <label className='form-label form-label-sm'>Formats</label>
                    <ul className='row px-0'>
                        { !isSuccess && formatFilterList.length === 0 && <p>Not available</p>}
                        { isSuccess && formatFilterList.length > 0 && 
                        formatFilterList.map((format) => { 
                                        return (<li className='col-4 col-lg-12 col-xl-6' key={format.formatId}>
                                                    <div className='d-flex mb-1'>
                                                        <input id={format.formatId} 
                                                            type='checkbox' 
                                                            className='flex-shrink-0 form-check-input' 
                                                            value={format.value} 
                                                            checked={format.isChecked}
                                                            onChange={changeCheckBoxHandler} />
                                                            <small htmlFor={format.formatId} className='form-check-label ms-2'>
                                                                {format.name}
                                                            </small>
                                                    </div>
                                                </li>)} 
                                                )}
                    </ul>
                </div>
         </div>)
};

export default FormatFilter;