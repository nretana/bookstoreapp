
import styles from './BookItem.module.scss';

const BookItem = ({ title = 'N/A', imageUrl = null, author = null }) => {
    return(<div className='col-6 col-sm-4 col-md-3 col-lg-3 px-md-2'>
                <div className='card h-100'>
                    <div className='card-header text-center px-0 pb-0'>
                        <img className={`${styles['card-book-img']}`} src={imageUrl} alt={title} />
                    </div>
                    <div className='card-body'>
                        <label className='card-title fw-bold d-block mb-0'>{title}</label>
                        <small className='text-muted'>by  <a href='/authors'>{author.firstName} {author.lastName}</a> </small>
                    </div>
                </div>
           </div>)
};

export default BookItem;