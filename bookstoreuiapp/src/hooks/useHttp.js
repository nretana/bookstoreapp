import { useState } from 'react';

const UseHttpRequest = () => {
    const [isLoading, setIsLoading] = useState(false);
    const [errorMessage, setErrorMessage] = useState(null);

    const SendHttpRequest = async (url, options, callback) => {
        try {
            setIsLoading(true);
            setErrorMessage(null);
            var response = await fetch(url);
            if(!response.ok){
                throw new Error('Error trying to access the URL');
            }

            const parseData = await response.json();

            if(parseData == null){
                throw new Error('Error trying to parse data');
            }

            if(callback !== null){
                const isProcessedData = callback(parseData);
                if(!isProcessedData){
                    throw new Error('Error trying to process data');
                }
            }
        }
        catch(error){
            setErrorMessage('There was a problem trying to retrieve information. Please, try again later.');
            setIsLoading(false);
        }
        
    }

    return { SendHttpRequest, isLoading, errorMessage };
}

export default UseHttpRequest;