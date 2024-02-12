import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const authorApi = createApi({
    reducerPath: 'authorApi',
    baseQuery: fetchBaseQuery({ baseUrl: `${process.env.REACT_APP_BOOSKTORE_API_URL}` }),
    endpoints: (builder) => ({
        getAllAuthors: builder.query({
            query: (params) =>{
                return {
                    url: '/authors',
                    params
                }
            },
            transformResponse: (response) => {
                return { authorList: response }
            }
        })
    })
});

export const { useGetAllAuthorsQuery } = authorApi;