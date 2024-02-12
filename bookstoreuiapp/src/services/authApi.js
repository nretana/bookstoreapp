import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { statusCodeErrorMessage } from '../utils/statusCodeErrorMessage';

const createRequest = (url) => ({ url });

export const authApi = createApi({
    reducerPath: 'authApi',
    baseQuery: fetchBaseQuery({ baseUrl: `${process.env.REACT_APP_BOOSKTORE_API_URL}/accounts` }),
    endpoints: (builder) => ({
        getUserAccount: builder.query({
            query: (userId) => createRequest(`getuseraccount/${userId}`)
        }),

        sendTwoStepCode: builder.mutation({
            query: (body) => ({
                url: '/sendtwostepcode',
                method: 'POST',
                body
            }),
            transformErrorResponse: response => {
                const errorMessage = statusCodeErrorMessage(response?.status, response?.data);
                return { errorMessage }
            },
        }),

        validateTwoStepCode: builder.mutation({
            query: (body) => ({
                url: '/validatetwostepcode',
                method: 'POST',
                body
            }),
            transformErrorResponse: response => {
                const errorMessage = statusCodeErrorMessage(response?.status, response?.data);
                return { errorMessage }
            },
        }),

        signIn: builder.mutation({
            query: (body) => ({
                url: '/signin',
                method: 'POST',
                body
            }),
            transformErrorResponse: response => {
                const errorMessage = statusCodeErrorMessage(response?.status, response?.data);
                return { errorMessage }
            },
            invalidatesTags: ['Account']
        }),

        signUp: builder.mutation({
            query: (body) => ({
                url: '/signup',
                method: 'POST',
                body
            }),
            transformErrorResponse: response => {
                const errorMessage = statusCodeErrorMessage(response?.status, response?.data);
                return { errorMessage }
            },
        }),

        sendEmailConfirmationCode: builder.mutation({
            query: (body) => ({
                url: '/sendemailconfirmationcode',
                method: 'POST',
                body
            }),
            transformErrorResponse: response => {
                const errorMessage = statusCodeErrorMessage(response?.status, response?.data);
                return { errorMessage }
            },
        }),

        validateEmailConfirmationCode: builder.mutation({
            query: (body) => ({
                url: '/validateemailconfirmationcode',
                method: 'POST',
                body
            }),
            transformErrorResponse: response => {
                const errorMessage = statusCodeErrorMessage(response?.status, response?.data);
                return { errorMessage }
            },
        }),

        sendPasswordResetCode: builder.mutation({
            query: (body) => ({
                url: '/sendpasswordresetcode',
                method: 'POST',
                body
            }),
            transformErrorResponse: response => {
                const errorMessage = statusCodeErrorMessage(response?.status, response?.data);
                return { errorMessage }
            },
        }),

        passwordReset: builder.mutation({
            query: (body) => ({
                url: '/passwordreset',
                method: 'POST',
                body
            }),
            transformErrorResponse: response => {
                const errorMessage = statusCodeErrorMessage(response?.status, response?.data);
                return { errorMessage }
            },
        })

    })
});

export const { useGetUserAccountQuery, 
               useSendTwoStepCodeMutation, 
               useValidateTwoStepCodeMutation, 
               useSignInMutation, 
               useSignUpMutation,
               useSendEmailConfirmationCodeMutation, 
               useValidateEmailConfirmationCodeMutation,
               useSendPasswordResetCodeMutation,
               usePasswordResetMutation } = authApi;