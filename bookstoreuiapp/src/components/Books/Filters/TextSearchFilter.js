import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useSearchParams } from 'react-router-dom';

import Form from 'react-bootstrap/Form';

import { textSearchFilterActions } from '../../../store/slices/textSearchFilterSlice';

const TextSearchFilter = () => {

    const dispatch = useDispatch();
    const [querySearchParams, setQuerySearchParams] = useSearchParams();
    const [textSearch, setTextSearch] = useState('');

    const currentTextSearchState = useSelector(state => state.textSearchFilterState);
    const textSearchQuery = currentTextSearchState.textSearchQuery ?? '';
    const searchQuery = querySearchParams.has('searchquery') ? querySearchParams.get('searchquery') : '';

    useEffect(() => {
        if(textSearchQuery.trim() === ''){
            setTextSearch('');
        }
    }, [textSearchQuery]);

    useEffect(() => {
        if(searchQuery.trim().length > 0){
            setTextSearch(searchQuery);
        }
    }, []);

    useEffect(() => {
        const executeTextSearch = setTimeout(function(){
            dispatch(textSearchFilterActions.setTextSearch({ textSearch }));
        }, 900);

        return () => {
            clearTimeout(executeTextSearch);
        }
    },[textSearch, dispatch]);

    const submitFormHandler = (e) => {
        e.preventDefault();
    }

    return(<div>
        <Form onSubmit={submitFormHandler}>
                <div className='mb-3'>
                    <label htmlFor='InputTextSearch' className='form-label'>Search</label>
                    <input id='InputTextSearch' type='text' className='form-control form-control-sm' 
                                               value={textSearch} 
                                               onChange={(e) =>setTextSearch(e.target.value) } />
                </div>
        </Form>
    </div>)
};

export default TextSearchFilter;