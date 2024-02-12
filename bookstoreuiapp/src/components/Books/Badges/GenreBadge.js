import { Fragment } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import Badge from 'react-bootstrap/Badge';
import Button from 'react-bootstrap/Button';
import { BsFillXCircleFill } from 'react-icons/bs';

import { genreFilterActions } from '../../../store/slices/genreFilterSlice';

const GenreBadge = () => {
    const dispatch = useDispatch();
    const currentGenreState = useSelector(state => state.genreFilterState);
    const genreFilterList = currentGenreState.genreFilterList ?? [];

    const clickBadgeHandler = (e) => {
        const genre = e.target.dataset?.genre;
        if(genre === null){
            return;
        }
        dispatch(genreFilterActions.removeGenreFromFilterList({ itemUnchecked: genre }));
    }

    return (<Fragment>
        {genreFilterList.length > 0 && 
         genreFilterList.map((item, index) => item.isChecked && <Badge as={Button} pill bg='primary'
                                                                       key={`badgeId${index}`}
                                                                       className='d-flex me-2 mb-2'
                                                                       data-genre={item.value}
                                                                       onClick={clickBadgeHandler}>
                                                                       <BsFillXCircleFill/>
                                                                       <span className='ms-1'>{item.name}</span>
                                                                </Badge>)
        }
    </Fragment>)
}

export default GenreBadge;