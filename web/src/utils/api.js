export const API_BASE_URL = 'https://lifeguard-hiij.onrender.com';

export const API_ENDPOINTS = {
    LOGIN: '/api/Account/login',
    REGISTER: '/api/Account/register',
    FORGOT_PASSWORD: '/api/Account/forgot-password'
};

export const fetchWithAuth = async (endpoint, options = {}) => {
    const defaultHeaders = {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
        'Access-Control-Allow-Headers': 'Content-Type, Authorization',
    };

    const response = await fetch(`${API_BASE_URL}${endpoint}`, {
        ...options,
        headers: {
            ...defaultHeaders,
            ...options.headers,
        },
        credentials: 'include', // This is important for cookies/sessions
    });

    if (!response.ok) {
        const error = await response.json();
        throw new Error(error.message || 'Something went wrong');
    }

    return response.json();
};

export const handleApiResponse = async (response) => {
    const data = await response.json();
    
    if (!response.ok) {
        throw new Error(data.message || 'An error occurred');
    }
    
    return data;
}; 