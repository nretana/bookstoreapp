import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const formatApi = createApi({
    reducerPath: 'formatApi',
    baseQuery: fetchBaseQuery({ baseUrl: `${process.env.REACT_APP_BOOSKTORE_API_URL}` }),
    endpoints: (builder) => ({
        getAllFormats: builder.query({
            query: (params) => {
                return {
                    url: '/formats',
                    params
                }
            },
            transformResponse: (response) => {
                return { formatList: response }
            },
            providesTags: ['Format']
        })
    })
});

export const { useGetAllFormatsQuery } = formatApi;