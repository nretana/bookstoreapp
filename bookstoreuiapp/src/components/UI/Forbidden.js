import styles from './Forbidden.module.scss';

const Forbidden = () => {
    const classSection = `container ${styles['forbidden-section']}`;
  return (
    <section className={classSection}>
      <div className='row justify-content-center align-items-center h-100'>
        <div className='col-6 text-center'>
          <h1 className={styles['forbidden-title']}>403</h1>
          <p className={styles['forbidden-sub-title']}>Access Denied</p>
          <p>You do not have permission to access this page. Please, sign in with your account.</p>
          <a href='/' className='btn btn-primary'>Go back to homepage</a>
        </div>
      </div>
    </section>
  );
};

export default Forbidden;
