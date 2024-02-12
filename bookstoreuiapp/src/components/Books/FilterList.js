import { Fragment } from 'react';

import FormatFilter from './Filters/FormatFilter';
import GenreFilter from './Filters/GenreFilter';
import TextSearchFilter from './Filters/TextSearchFilter';

const FilterList = (props) => {
    return(
      <Fragment>
        <div className='d-flex justify-content-between'>
        <h3 className='text-start'>Filter By</h3>
        <button className={`btn-close d-block d-lg-none`}
                          type='button' 
                          onClick={props.handleToggle}
                          aria-expanded='false' 
                          aria-label='Toggle navigation'>
                          </button>
        </div>
        <div className='mt-3'>
            <TextSearchFilter />
            <hr />
            <GenreFilter />
            <hr />
            <FormatFilter />
        </div>
      </Fragment>)
};

export default FilterList;