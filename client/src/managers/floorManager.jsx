const _apiUrl = "/api/floor";

export const GetAllFloors = () => {
    return fetch(_apiUrl).then((res) => res.json())
}