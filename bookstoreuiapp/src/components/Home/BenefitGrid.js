import styles from './BenefitGrid.module.scss';

import benefitImg1Url from '../../assets/imgs/shayna-douglas-LVtTIR8SyjU-unsplash.webp';
import benefitImg2Url from '../../assets/imgs/shiromani-kant-mo3FOTG62ao-unsplash.webp';
import benefitImg3Url from '../../assets/imgs/sincerely-media-_-hjiem5TqI-unsplash.webp';
import benefitImg4Url from '../../assets/imgs/abbat-hY1Y3Xxo7Uw-unsplash.webp';
import benefitImg5Url from '../../assets/imgs/mel-poole-lBsvzgYnzPU-unsplash.webp';

const BenefitGrid = () => {
  return (
    <section className={`${styles['benefit-section']}`}>
      <div className='container my-6'>
        <div className={`${styles['grid-container']}`}>
          <div className={`${styles['grid-item-1']}`}>
            <img className={`${styles['grid-img']}`} src={benefitImg1Url} alt='The little book of Hygge'/>
          </div>
          <div className={`${styles['grid-item-2']} d-flex p-4`}>
            <div className={`${styles['grid-box']}`}>
              <h3 className={`${styles['grid-title']}`}>Find Variety of Books</h3>
              <p className={`${styles['grid-description']} mb-0`}>Our online bookstore features the best books, eBooks, and audiobooks from bestselling authors.</p>
            </div>
          </div>
          <div className={`${styles['grid-item-3']}`}>
            <div className={`${styles['sub-grid-item-1']}`}>
              <img className={`${styles['grid-img']}`} src={benefitImg2Url} alt='Stack of books' />
            </div>
            <div className={`${styles['sub-grid-item-2']} d-flex p-4`}>
              <div className={`${styles['grid-box']}`}>
                <h3 className={`${styles['grid-title']}`}>Discover a New World</h3>
                <p className={`${styles['grid-description']} mb-0`}>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt 
                        ut labore et dolore magna.</p>
              </div>
            </div>
            <div className={`${styles['sub-grid-item-3']}`}>
              <img className={`${styles['grid-img']}`} src={benefitImg3Url} alt='Open book with coffee and a pair of glasses' />
            </div>
          </div>
          <div className={`${styles['grid-item-4']}`}>
            <img className={`${styles['grid-img']} ${styles['position-top']}`} src={benefitImg4Url} alt='Woman reading a book'/>
          </div>
          <div className={`${styles['grid-item-5']}`}>
            <img className={`${styles['grid-img']}`} src={benefitImg5Url} alt='Open text book'/>
          </div>
          <div className={`${styles['grid-item-6']} d-flex p-4`}>
          <div className={`${styles['grid-box']}`}>
              <h3 className={`${styles['grid-title']}`}>The Best Bookstore</h3>
              <p className={`${styles['grid-description']} mb-0`}>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut 
                        labore et dolore magna aliquyam erat, sed diam voluptua</p>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default BenefitGrid;
