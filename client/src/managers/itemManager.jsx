const _apiUrl = "/api/item";

export const GetUserItems = (id) => {
    return fetch(_apiUrl + `/${id}`).then((res) => res.json())
}

export const PostItem = (i) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(i)
    })
}

export const EditItem = (i) => {
    return fetch(`${_apiUrl}/${i.itemId}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(i)
    })
}

export const DeleteItem = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(id)
    })
}

export const GetOneItem = (id) => {
    return fetch(_apiUrl + `/single/${id}`).then((res) => res.json())
}