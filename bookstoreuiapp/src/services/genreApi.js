import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const genreApi = createApi ({
    reducerPath: 'genreApi',
    baseQuery: fetchBaseQuery({ baseUrl: `${process.env.REACT_APP_BOOSKTORE_API_URL}` }),
    endpoints: (builder) => ({
        getAllGenres: builder.query({
            query: (params) => {
                return {
                    url: '/genres',
                    params
                }
            },
            transformResponse: (response) => {
                return { genreList: response }
            },
            providesTags: ['Genre']
        })
    })
});

export const { useGetAllGenresQuery } = genreApi;