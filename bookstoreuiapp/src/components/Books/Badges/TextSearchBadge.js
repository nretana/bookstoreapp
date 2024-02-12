import { useDispatch, useSelector } from 'react-redux';

import Badge from 'react-bootstrap/Badge';
import Button from 'react-bootstrap/Button';
import { BsFillXCircleFill } from 'react-icons/bs';

import { textSearchFilterActions } from '../../../store/slices/textSearchFilterSlice';

const TextSearchBadge = () => {
    const dispatch = useDispatch();

    const currentTextSearchState = useSelector(state => state.textSearchFilterState);
    const textSearchQuery = currentTextSearchState.textSearchQuery ?? '';

    const clickBadgeHandler = (e) => {
        dispatch(textSearchFilterActions.clearTextSearch());
    };

    return(<>
        { textSearchQuery.length > 0 && <Badge as={Button} pill bg='primary' 
                                                           className='d-flex me-2 mb-2' 
                                                           onClick={clickBadgeHandler}>
                                                             <BsFillXCircleFill/>
                                                             <span className='ms-1'>{textSearchQuery}</span>
                                        </Badge> }
        </>)
};

export default TextSearchBadge;