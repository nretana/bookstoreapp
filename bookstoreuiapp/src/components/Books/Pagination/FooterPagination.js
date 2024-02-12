import { Fragment } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { Pagination } from 'react-bootstrap';

import { paginationActions } from '../../../store/slices/paginationSlice';

const FooterPagination = () => {

    const currentBookState = useSelector(state => state.bookState);
    const totalCount = currentBookState.pagination.totalCount;
    const totalPages = currentBookState.pagination.totalPages;
    const currentPage = currentBookState.pagination.currentPage;
    const hasPrevious = currentBookState.pagination.hasPrevious;
    const hasNext = currentBookState.pagination.hasNext;
    const dispatch = useDispatch();

    const clickPageNumberHandler = (e) => {
        e.preventDefault();
        dispatch(paginationActions.setPageNumber(e.target.dataset.value));
    };

    const clickIncreasePageNumberHandler = (e) => {
        e.preventDefault();
        dispatch(paginationActions.increasePageNumber());
    };

    const clickDecreasePageNumberHandler = (e) => {
        e.preventDefault();
        dispatch(paginationActions.decreasePageNumber());
    };

    const GeneratePaginationItems = (totalPages, currentPage) => {
        var paginationItems = [];
        for (let num = 1; num <= totalPages; num++){
            paginationItems.push(<Pagination.Item key={num} 
                                                  active={num === currentPage}
                                                  //disabled= {num === currentPage}
                                                  onClick={clickPageNumberHandler} 
                                                  data-value={num}>
                                    {num}
                                </Pagination.Item>);
       }

       return (<Fragment>{paginationItems}</Fragment>)
    };

    return(<Fragment>
        {(totalCount > 0) &&
                <Pagination className='mt-5'>
                    <Pagination.Prev disabled={!hasPrevious} onClick={clickDecreasePageNumberHandler}>
                        <small>Previous</small>
                    </Pagination.Prev>
                    { GeneratePaginationItems(totalPages, currentPage) }
                    <Pagination.Next disabled={!hasNext} onClick={clickIncreasePageNumberHandler}>
                        <small>Next</small>
                    </Pagination.Next>
                </Pagination>}
        </Fragment>)
}

export default FooterPagination;