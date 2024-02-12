import { useState } from 'react';
import { useDispatch } from 'react-redux';

import Dropdown from 'react-bootstrap/Dropdown';

import { paginationActions } from '../../../store/slices/paginationSlice';

const sortByOptionsList = [
    { text: 'Author - A to Z', value: 'author.firstname,author.lastname asc', isCurrent: false },
    { text: 'Author - Z to A', value: 'author.firstname,author.lastname desc', isCurrent: false },
    { text: 'Title - A to Z', value: 'title asc', isCurrent: true },
    { text: 'Title - Z to A', value: 'title desc', isCurrent: false }
  ];

const pageSizeOptionsList = [
    { text: '10', value: '10', isCurrent: true },
    { text: '20', value: '20', isCurrent: false },
    { text: '30', value: '30', isCurrent: false },
    { text: '40', value: '40', isCurrent: false }
  ];

const SettingPagination = () => {
    const [sortByList, setSortByList] = useState(sortByOptionsList);
    const [pageSizeList, setPageSizeList] = useState(pageSizeOptionsList);
    const dispatch = useDispatch();

    const currentSortItem = sortByList.find(item => item.isCurrent);
    const currentSortText = currentSortItem?.text;
    const currentSortValue = currentSortItem?.value;

    const currentPageSizeItem = pageSizeList.find(item => item.isCurrent);
    const currentPageSizeText = currentPageSizeItem?.text;
    const currentPageSizeValue = currentPageSizeItem?.value;

    const changePageSizeHandler = (e) => {
        e.preventDefault();
        const value = e.target.dataset?.value ?? null;
        if(value === null){
          return;
        }

        if(currentPageSizeValue === value){
          return;
        }
        
        setPageSizeList(prevState => {
          const newIndex = prevState.findIndex(item => item.value === value);
          const currentIndex = prevState.findIndex(item => item.value === currentPageSizeValue);
    
          prevState[newIndex].isCurrent = true;
          prevState[currentIndex].isCurrent = false;
          return [...prevState];
        });

        dispatch(paginationActions.setPageSize(parseInt(value)));
    }

    const changeSortingHandler = (e) => {
        e.preventDefault();
        const value = e.target.dataset?.value ?? null;
    
        if(value === null){
          return;
        }
    
        if(currentSortValue === value){
          return;
        }
    
        setSortByList(prevState => {
          const newIndex = prevState.findIndex(item => item.value === value.trim());
          const currentIndex = prevState.findIndex(item => item.value === currentSortValue);
    
          prevState[newIndex].isCurrent = true;
          prevState[currentIndex].isCurrent = false;
          return [...prevState];
        });

        dispatch(paginationActions.setOrderBy(value));
      };
    
    return(<div className='d-flex justify-content-md-end'>
         { pageSizeList.length > 0 && <Dropdown className='me-2'>
                                          <Dropdown.Toggle id='DropDownPageView' size='sm'>
                                            Show - {currentPageSizeText}
                                          </Dropdown.Toggle>
                                          <Dropdown.Menu className='dropdown-sm' role='menu'>
                                            {pageSizeList.map((item, index) => <Dropdown.Item as='button' 
                                                                                            key={`pageViewId${index}`}
                                                                                            onClick={changePageSizeHandler} 
                                                                                            data-value={item.value}>
                                                                                            {item.text}
                                                                                            </Dropdown.Item>)}
                                          </Dropdown.Menu>
                                      </Dropdown> }
        { sortByList.length > 0 && <Dropdown>
                                      <Dropdown.Toggle id='DropDownSort' size='sm'>
                                        {currentSortText}
                                      </Dropdown.Toggle>
                                      <Dropdown.Menu className='dropdown-sm' role='menu'>
                                        {sortByList.map((item, index) => <Dropdown.Item as='button' 
                                                                                        key={`sortId${index}`}
                                                                                        onClick={changeSortingHandler} 
                                                                                        data-value={item.value}>
                                                                                        {item.text}
                                                                                        </Dropdown.Item>)}
                                      </Dropdown.Menu>
                                    </Dropdown> }
          </div>)
}

export default SettingPagination;