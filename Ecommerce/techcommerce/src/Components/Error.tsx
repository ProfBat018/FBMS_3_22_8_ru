import React, {useEffect} from 'react';
import {ErrorDTO} from "../Models/ErrorDTOs";

// Пример изображения для разных типов ошибок (реальные ссылки)
const errorImages = {
    InvalidToken: 'https://unsplash.com/photos/MBG9F8bYrZo',
    InvalidRefreshToken: 'https://unsplash.com/photos/XkKCui44iM0',
    InvalidCredentials: 'https://unsplash.com/photos/nPxXWgQ33ZQ',
    UserNotFound: 'https://unsplash.com/photos/1K6IQsQbizI',
    InvalidRequest: 'https://unsplash.com/photos/LfvnQDPDYfE',
    PasswordMismatch: 'https://unsplash.com/photos/Fhn2lZYWL-4',
    EmailNotConfirmed: 'https://unsplash.com/photos/-OKLRe6z88Y',
    EmailAlreadyConfirmed: 'https://unsplash.com/photos/UxXoRz53b1k',   
};

// Enum для типов ошибок


const ErrorPage = ({errorData}: {errorData: ErrorDTO}) => {
    
    useEffect(() => {
        console.log(errorData);
    });
    
    return (
        <div className="flex flex-col items-center justify-center min-h-screen bg-black text-white px-4">
            <h1 className="text-8xl font-bold mb-4">{errorData.errorCode}</h1>
            <h3 className="text-4xl font-semibold mb-6">{errorData.errorType.replace(/([A-Z])/g, ' $1').trim()}</h3>
            <p className="text-xl mb-8 text-center max-w-2xl">{errorData.errorMessage}</p>

            {/* Фото для ошибки */}
            <div className="w-full flex justify-center">
                <img
                   
                    alt={errorData.errorType}
                    className="max-w-md rounded-lg shadow-lg"
                />
            </div>
        </div>
    );
};

export default ErrorPage;
