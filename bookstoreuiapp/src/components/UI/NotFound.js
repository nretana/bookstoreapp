import styles from './NotFound.module.scss';

const NotFound = () => {
    const classSection = `container ${styles['notfound-section']}`;
  return (
    <section className={classSection}>
      <div className='row justify-content-center align-items-center h-100'>
        <div className='col-6 text-center'>
          <h1 className={styles['notfound-title']}>404</h1>
          <p className={styles['notfound-sub-title']}>Page Not Found</p>
          <p>We were unable to find the page you were looking for.</p>
          <a href='/' className='btn btn-primary'>Go back to homepage</a>
        </div>
      </div>
    </section>
  );
};

export default NotFound;
