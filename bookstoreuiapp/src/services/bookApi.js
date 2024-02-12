import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const createRequest = (url) => ({ url });

export const bookApi = createApi({
    reducerPath: 'bookApi',
    baseQuery: fetchBaseQuery({ baseUrl: `${process.env.REACT_APP_BOOSKTORE_API_URL}`,
                                prepareHeaders: (headers, {getState}) => {
                                    const token = localStorage.getItem("CID");
                                    if(token){
                                        headers.set('Access-Control-Allow-Origin','*');
                                        headers.set('authorization', `Bearer ${token}`);
                                    }
                                    return headers;
                                }, }),
    endpoints: (builder) => ({
        getAllBooks: builder.query({
            query: (params) => {
                const queryParams = {
                    ...(params.genres.trim().length > 0 && { genres: params.genres }),
                    ...(params.formats.trim().length > 0 && { formats: params.formats }),
                    pageSize: params.pageSize,
                    pageNumber: params.pageNumber,
                    ...(params.searchQuery.trim().length > 0 && { searchQuery: params.searchQuery }),
                    ...(params.orderBy.trim().length > 0 && { orderBy: params.orderBy })
                };
                return {
                    url: '/books',
                    method: 'GET',
                    params: queryParams
                }
            },
            transformResponse: (response, meta) => {
                return { bookList: response, pagination: JSON.parse(meta.response.headers.get('X-Pagination')) }
            },
            providesTags: ['Book']
        }),

        getBook: builder.query({
            query: (bookId) => createRequest(`/books/${bookId}`)
        })

    })
});

export const { useGetAllBooksQuery, 
               useGetBookQuery } = bookApi;