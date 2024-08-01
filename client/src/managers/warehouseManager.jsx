const _apiUrl = "/api/warehouse";

export const GetAllWarehouses = () => {
    return fetch(_apiUrl).then((res) => res.json())
}