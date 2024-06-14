const _apiUrl = "/api/category";

export const GetAllCategories = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const GetFloorCategories = (id) => {
    return fetch(`${_apiUrl}/floor/${id}`).then((res) => res.json())
}