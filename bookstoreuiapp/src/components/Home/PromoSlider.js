import { useState, useEffect } from 'react';

import styles from './PromoSlider.module.scss';
import promoImg from '../../assets/imgs/promo/promo-book-fair.jpg';
import promoImg2 from '../../assets/imgs/promo/promo-children-books.jpg';
import promoImg3 from '../../assets/imgs/promo/promo-free-delivery.jpg';

const sliderItems = [{ id: 'promo_001', imgUrl: promoImg,  description: 'Book fairs in 2023', isActive: true },
                     { id: 'promo_002', imgUrl: promoImg2,  description: 'Kid reading a book', isActive: false },
                     { id: 'promo_003', imgUrl: promoImg3,  description: 'Books with flowers', isActive: false }];

const PromoSlider = () => {
    const [promoList, setPromoList] = useState(sliderItems);
    const [isResetInterval, SetIsResetInterval] = useState(false);

    const runSlider = () => {
        const updatePromoList = promoList.slice();
        var currentItemIndex = updatePromoList.findIndex(item => item.isActive);
        updatePromoList[currentItemIndex].isActive = false;

        var newItemIndex = (currentItemIndex + 1) % promoList.length; //(currentItemIndex + 1) < updatePromoList.length ? (currentItemIndex + 1) : 0;
        updatePromoList[newItemIndex].isActive = true;

        setPromoList([...updatePromoList]);
    }
  
    useEffect(() => {
        let intervalFunc = setInterval(runSlider, 6000);

        return () => {
            clearInterval(intervalFunc);
        }
    }, [isResetInterval]);

    const prevSlideHandler = (e) => {
        e.preventDefault();
        const updatePromoList = promoList.slice();
        var currentItemIndex = updatePromoList.findIndex(item => item.isActive);
        updatePromoList[currentItemIndex].isActive = false;

        var newItemIndex = (currentItemIndex - 1) > -1 ? (currentItemIndex - 1) : updatePromoList.length - 1;
        updatePromoList[newItemIndex].isActive = true;

        setPromoList([...updatePromoList]);
        SetIsResetInterval(!isResetInterval);
    };

    const nextSlideHandler = (e) => {
        e.preventDefault();
        runSlider();
        SetIsResetInterval(!isResetInterval);
    };

    return(<section className={`${styles['promo-slider-section']}`}>
        <div className={`container ${styles['promo-content']}`}>
            <div className={`row g-0 px-0 ${styles['promo-slider-content']}`}>
                <div className='col-1 align-self-center'>
                    <button className={`${styles['slider-button-prev']} btn btn-primary`} onClick={prevSlideHandler} aria-label='prev slide'>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="24" height="24">
                            <path d="M15.28 5.22a.75.75 0 0 1 0 1.06L9.56 12l5.72 5.72a.749.749 0 0 1-.326 1.275.749.749 0 0 1-.734-.215l-6.25-6.25a.75.75 
                            0 0 1 0-1.06l6.25-6.25a.75.75 0 0 1 1.06 0Z"></path>
                        </svg>
                    </button>
                </div>
                <div className='col-10'>
                    {sliderItems.map(item =>
                        <div key={item.id}
                            className={`${styles['slider-item']} ${item.isActive ? styles['active'] : ''}`}
                            data-value={item.id}>
                                <img className='img-fluid' src={item.imgUrl} alt={item.description} />
                        </div>
                    )}
                </div>
                <div className='col-1 align-self-center'>
                    <button className={`${styles['slider-button-next']} btn btn-primary`} onClick={nextSlideHandler} aria-label='next slide'>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="30" height="30">
                            <path d="M8.72 18.78a.75.75 0 0 1 0-1.06L14.44 12 8.72 6.28a.751.751 0 0 1 .018-1.042.751.751 0 0 1 1.042-.018l6.25 
                            6.25a.75.75 0 0 1 0 1.06l-6.25 6.25a.75.75 0 0 1-1.06 0Z"></path>
                        </svg>
                    </button>
                </div>
            </div>
            
           
        </div>
    </section>)
};

export default PromoSlider;