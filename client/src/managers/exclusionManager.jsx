const _apiUrl = "/api/Exclusion";

export const GetAllExclusions = () => {
    return fetch(_apiUrl).then((res) => res.json())
}