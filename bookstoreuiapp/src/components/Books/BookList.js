import { Fragment, useState, useEffect } from 'react';
import { useDispatch, useSelector, shallowEqual } from 'react-redux';

import BookItem from './BookItem';
import Loading from '../UI/Loading';

import { bookActions } from '../../store/slices/bookSlice';
import { useGetAllBooksQuery } from '../../services/bookApi';

const BookList = () => {
    const pageNumber = useSelector(state => state.paginationState.pageNumber, shallowEqual) ?? 1;
    const pageSize = useSelector(state => state.paginationState.pageSize, shallowEqual) ?? 1;
    const orderBy = useSelector(state => state.paginationState.orderBy, shallowEqual) ?? '';
    const formatsQuery = useSelector(state => state.formatFilterState.formatsQuery, shallowEqual) ?? '';
    const genresQuery = useSelector(state => state.genreFilterState.genresQuery, shallowEqual) ?? '';
    const textSearchQuery = useSelector(state => state.textSearchFilterState.textSearchQuery, shallowEqual) ?? '';
    const bookList = useSelector(state => state.bookState.bookList, shallowEqual) ?? [];

    //query params
    const searchParams  = new URLSearchParams(window.location.search);
    const orderByQueryString = searchParams.has('orderby') ? searchParams.get('orderby') : '';
    const formatsByQueryString = searchParams.has('formats') ? searchParams.get('formats') : '';
    const genresQueryString = searchParams.has('genres') ? searchParams.get('genres') : '';
    const searchQueryString = searchParams.has('searchquery') ? searchParams.get('searchquery') : '';
    console.log("QueryString on refresh component: ", genresQueryString, formatsByQueryString, searchQueryString, orderByQueryString);
    
    const [isRefetch, setIsRefetch] = useState(false);
    const dispatch = useDispatch();
    const { data, isSuccess, isError, 
            refetch, isLoading, 
            isFetching } = useGetAllBooksQuery({ genres: (genresQueryString.length > 0 && genresQuery.length === 0 ? genresQueryString : genresQuery),
                                                 formats: (formatsByQueryString.length > 0 && formatsQuery.length === 0 ? formatsByQueryString : formatsQuery),
                                                 pageSize, 
                                                 pageNumber, 
                                                 searchQuery: (searchQueryString.length > 0 && textSearchQuery.length === 0 ? searchQueryString : textSearchQuery),
                                                 orderBy: (orderByQueryString.length > 0 && orderBy.length === 0 ? orderByQueryString : orderBy) }, { skip: false } );

    useEffect(() => {
        console.log("refetch books");
        setIsRefetch(!isRefetch);
    }, [genresQuery, formatsQuery, textSearchQuery, orderBy, pageNumber, pageSize])

    useEffect(() => {
        if (isSuccess && data) {
            dispatch(bookActions.setBookList({ bookList: data.bookList, pagination: data.pagination }));
        }
    }, [isSuccess, isError, data, dispatch]);

    return(<Fragment>
                { (isLoading || isFetching) && <Loading /> }
                {(!isSuccess || bookList.length === 0) &&
                <p className='text-muted'>We didn't find any book based on your search.</p>}
                {isSuccess && 
                 <div className='row g-3'>
                        {bookList.length > 0 &&  
                        bookList.map( bookItem => {
                            return <BookItem key={bookItem.bookId} 
                                             title={bookItem.title}
                                             imageUrl={bookItem.imageUrl} 
                                             author={bookItem.author}
                                             format={bookItem.format}
                                             genres={bookItem.genres} />
                        })}
                 </div>}
         </Fragment>)
};

export default BookList;