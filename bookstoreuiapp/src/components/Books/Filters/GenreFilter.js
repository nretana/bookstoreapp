import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useSearchParams } from 'react-router-dom';

import { useGetAllGenresQuery } from '../../../services/genreApi';
import { genreFilterActions } from '../../../store/slices/genreFilterSlice';

const GenreFilter = () => {

    const { data, isSuccess, isError } = useGetAllGenresQuery();
    const dispatch = useDispatch();
    const [querySearchParams, setQuerySearchParams] = useSearchParams();

    const currentGenreState = useSelector(state => state.genreFilterState);
    const genreFilterList = currentGenreState.genreFilterList;

    const genreQuery = querySearchParams.has('genres') ? querySearchParams.get('genres') : '';

    useEffect(() => {
        if(isSuccess && data){
            dispatch(genreFilterActions.setGenreFilterList({ dataList: data.genreList, genreQuery }));
        }
    }, [isSuccess, isError, data, dispatch]);

    const changeCheckBoxHandler = (e) => {
        const value = e.target.value;
        const isChecked = e.target.checked;
        isChecked ? dispatch(genreFilterActions.addGenreToFilterList({ itemChecked: value })) :
                    dispatch(genreFilterActions.removeGenreFromFilterList({ itemUnchecked: value }));
    };

    return(<div className='mt-3'>
            <div>
                <label className='form-label form-label-sm'>Genres</label>
                <ul className='row px-0'>
                    { !isSuccess && genreFilterList.length === 0 && <p>Not available</p>}
                    { genreFilterList.length > 0 && 
                      genreFilterList.map((genre) => { 
                                    return (<li className='col-4 flex-grow-0 col-lg-12 col-xl-6' key={genre.genreId}>
                                                <div className='d-flex mb-1'>
                                                    <input id={genre.genreId} 
                                                        type='checkbox' 
                                                        className='flex-shrink-0 form-check-input' 
                                                        value={genre.name} 
                                                        checked={genre.isChecked}
                                                        onChange={changeCheckBoxHandler} />
                                                        <small htmlFor={genre.genreId} className='form-check-label ms-2'>
                                                            {genre.name}
                                                        </small>
                                                </div>
                                            </li>)} 
                                            ) }
                </ul>
            </div>
    </div>)
};

export default GenreFilter;