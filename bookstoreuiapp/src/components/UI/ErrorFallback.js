import { BsExclamationTriangle } from 'react-icons/bs';

const ErrorFallback = ({ error, resetErrorBoundary }) => {
    return(<div className='row'>
        <div>
            <BsExclamationTriangle />
            <h1>Opps! Something went wrong.</h1>
            <button className='btn btn-primary' onClick={resetErrorBoundary}>Try again</button>
        </div>
    </div>)
}

export default ErrorFallback;