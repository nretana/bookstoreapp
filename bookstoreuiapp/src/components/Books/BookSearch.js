import { useState } from 'react';

import Tab from 'react-bootstrap/Tab';
import BookList from './BookList';
import BadgeList from './BadgeList';
import FilterList from './FilterList';
import FooterPagination from './Pagination/FooterPagination';
import SettingPagination from './Pagination/SettingPagination';

import styles from './BookSearch.module.scss';

import { BsFilterLeft } from 'react-icons/bs';


const BookSearch = () => {
  const [show, setShow] = useState(false);
  const handleToggle = () => { 
    (!show) ? document.body.classList.add('overflow-hidden') : document.body.classList.remove('overflow-hidden');
    setShow(!show);
  };
  
  return (<div className='container pt-6'>
            <div className='row flex-nowrap g-0'>
              <div className={`col-lg-3 ${styles['side-section']}`}>
                  <div className={`${styles['content-collapse']} ${ show ? styles['show'] : '' }`}
                       id='navbarSupportedContent'>
                       <div className='row'>
                         <FilterList handleToggle={handleToggle} />
                       </div>
                  </div>
              </div>
              <div className='col-12 col-lg-9 px-0'>
                      <h1>Search Books</h1>
                      <div className='row justify-content-between my-3'>
                        <div className='col-12 col-lg-8'>
                          <BadgeList />
                        </div>
                        <div className='col-12 col-lg-4'>
                          <div className='d-flex justify-content-lg-end text-nowrap'>
                            <button className={`btn btn-primary btn-sm ${styles['content-collapse-toggler']} me-2`}
                                    type='button'
                                    onClick={handleToggle}
                                    aria-controls='navbarSupportedContent'
                                    aria-expanded='false'
                                    aria-label='Toggle navigation'>
                                    <BsFilterLeft size={'16px'} />
                                    <span className='ms-1'>Filter</span>
                            </button>
                            <SettingPagination />
                          </div>
                        </div>
                      </div>
                      <BookList />
                      <FooterPagination />
              </div>
            </div>
        </div>);
};

export default BookSearch;
