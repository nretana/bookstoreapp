import styles from './HeroHeader.module.scss';

const HeroHeader = () => {

    return(<section className={`${styles['home-section']}`}>
        <div className='container h-100'>
            <div className='row align-items-center h-100'>
                <div className='col-12 col-lg-5'>
                    <div>
                        <h1 className={styles['hero-title']}>Find Your Next Book</h1>
                        <p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor 
                        invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam 
                        et justo duo dolores.</p>
                        <button className='btn btn-primary'>Discover More</button>
                    </div>
                </div>
                <div className='col-7'></div>
            </div>
        </div>
    </section>)
};

export default HeroHeader;