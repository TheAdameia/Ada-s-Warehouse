const _apiUrl = "/api/itemCategory";

export const GetAllItemCategories = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

export const PostItemCategory = (ic) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify(ic)
    })
}

export const DeleteItemCategory = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: "DELETE",
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify(id)
    })
}