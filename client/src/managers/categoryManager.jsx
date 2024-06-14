const _apiUrl = "/api/category";

export const GetAllCategories = () => {
    return fetch(_apiUrl).then((res) => res.json())
}