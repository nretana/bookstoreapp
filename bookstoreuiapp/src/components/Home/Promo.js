import styles from './Promo.module.scss';
import promoImgUrl from '../../assets/imgs/promo/promo-book-fair.jpg';

const Promo = () => {
    return(<section className={`${styles['promo-section']}`}>
        <div className={`container g-0 ${styles['promo-container']}`}>
            <div className={`row p-6 g-0 ${styles['row']}`}>
                <div className={`col-7 ${styles['col']}`}>
                    <img className='img-fluid' src={promoImgUrl} alt='picture of scattered books'/>
                </div>
                <div className={`col-5 px-5 ${styles['col']}`}>
                    <div>
                        <h2 className={`${styles['display-title']}`}>Online Book Fairs 2023</h2>
                        <p className='px-2'>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod 
                        tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.</p>
                        <button className='btn btn-primary'>Learn More</button>
                    </div>
                </div>
            </div>
        </div>
    </section>)
};

export default Promo;