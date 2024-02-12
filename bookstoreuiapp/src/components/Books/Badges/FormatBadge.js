import { Fragment } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import Badge from 'react-bootstrap/Badge';
import Button from 'react-bootstrap/Button';
import { BsFillXCircleFill } from 'react-icons/bs';

import { formatFilterActions } from '../../../store/slices/formatFilterSlice';

const FormatBadge = () => {

    const dispatch = useDispatch();
    const currentFormatState = useSelector(state => state.formatFilterState);
    const formatFilterList = currentFormatState.formatFilterList ?? [];

    const clickBadgeHandler = (e) => {
        const format = e.target.dataset?.format;
        if(format === null){
            return;
        }
        dispatch(formatFilterActions.removeFormatFromFilterList({ itemUnchecked: format }));
    }

    return(<Fragment>
        {formatFilterList.length > 0 && 
         formatFilterList.map((item, index) => item.isChecked && <Badge as={Button} pill bg='primary'
                                                                        key={`badgeId${index}`}
                                                                        className='d-flex me-2 mb-2'
                                                                        data-format={item.value}
                                                                        onClick={clickBadgeHandler}>
                                                                          <BsFillXCircleFill/>
                                                                          <span className='ms-1'>{item.name}</span>
                                                                 </Badge>)
        }
    </Fragment>)
}

export default FormatBadge;