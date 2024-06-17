const _apiUrl = "/api/floor";

export const GetAllFloors = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const GetOneFloor = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json())
}