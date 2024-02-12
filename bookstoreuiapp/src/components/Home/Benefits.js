import styles from './Benefits.module.scss';

import benefitImg1Url from '../../assets/imgs/shayna-douglas-LVtTIR8SyjU-unsplash.webp';
import benefitImg2Url from '../../assets/imgs/shiromani-kant-mo3FOTG62ao-unsplash.webp';
import benefitImg3Url from '../../assets/imgs/sincerely-media-_-hjiem5TqI-unsplash.webp';
import benefitImg4Url from '../../assets/imgs/abbat-hY1Y3Xxo7Uw-unsplash.webp';
import benefitImg5Url from '../../assets/imgs/mel-poole-lBsvzgYnzPU-unsplash.webp';

const Benefits = () => {
    return(<section className={`${styles['benefit-section']}`}>
        <div className='container my-6'>
            <div className='row py-3 g-0'>
                <div className='col-8 pe-3'>
                    <img className='img-fluid' src={benefitImg1Url} />
                </div>
                <div className='col-4 ps-3 inset-bottom-1'>
                    <div className='h-100 bg-danger'>
                        <h3>title</h3>
                        <p>description</p>
                    </div>
                </div>
            </div>
            <div className='row py-3 g-0'>
                <div className='col-8'>
                    <div className='row pe-3'>
                        <div className='col-6 pe-3'>
                            <img className='img-fluid' src={benefitImg2Url} />
                        </div>
                        <div className='col-6 ps-3'>
                            <div className='row flex-column h-100'>
                                <div className='col'>
                                    <h3>title</h3>
                                    <p>description</p>
                                </div>
                                <div className='col'>
                                    <img className='img-fluid' src={benefitImg3Url} />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className='col-4 offset-top-1 ps-3'>
                    <img className='img-fluid object-fit-cover h-100' src={benefitImg4Url} />
                </div>
            </div>
            <div className='row py-3 g-0'>
                <div className='col-9 pe-3'>
                    <img className='img-fluid' src={benefitImg5Url} />
                </div>
                <div className='col-3 ps-3'>
                    <div>
                        <h3>title</h3>
                        <p>description</p>
                    </div>
                </div>
            </div>
        </div>
    </section>)
};

export default Benefits;