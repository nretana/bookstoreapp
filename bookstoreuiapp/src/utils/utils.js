const utils = {
    updateQuerySearchParams: function(genresQuery = '', formatsQuery = '', textSearchQuery = '', orderBy = '', pageSize, pageNumber) {
        const searchParams  = new URLSearchParams(window.location.search);
        genresQuery.trim().length > 0 ? searchParams.set('genres', genresQuery) : searchParams.delete('genres');
        formatsQuery.trim().length > 0 ? searchParams.set('formats', formatsQuery) : searchParams.delete('formats');
        textSearchQuery.trim().length > 0 ? searchParams.set('searchquery', textSearchQuery) : searchParams.delete('searchquery');
        pageSize > 1 ? searchParams.set('pagesize', pageSize) : searchParams.delete('pagesize');
        pageNumber > 1 ? searchParams.set('pagenumber', pageNumber) : searchParams.delete('pagenumber');
        orderBy.trim().length > 0 ? searchParams.set('orderby', orderBy) : searchParams.delete('orderby');

        const searchParamsValue = searchParams.toString().trim().length > 0 ? `?${searchParams.toString()}` : window.location.pathname;
        window.history.replaceState(null, null, searchParamsValue);

    },
    updateSpecificQuerySearchParam: function(key, value) {
        const searchParams  = new URLSearchParams(window.location.search);
        value.toString().trim().length > 0 ? searchParams.set(key, value.toString()) : searchParams.delete(key);

        const searchParamsValue = searchParams.toString().trim().length > 0 ? `?${searchParams.toString()}` : window.location.pathname;
        window.history.replaceState(null, null, searchParamsValue);
    }
}

export default utils;