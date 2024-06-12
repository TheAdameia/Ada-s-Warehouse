import { useEffect, useState } from "react"
import { ItemCard } from "./ItemCard"
import { GetUserItems } from "../../managers/itemManager"


export const ItemList = ({ loggedInUser }) => {
    const [items, setItems] = useState([])

    const getItems = () => {
        GetUserItems(loggedInUser.id).then(setItems)
    }

    useEffect(() => {
        getItems()
    }, [])

    return (
        <div className="items-container">
            <h2>My Items</h2>
            <article className="items">
                {items.map((item) => {
                    return (
                        <ItemCard
                            item={item}
                            key={`item-${item.itemId}`}
                        ></ItemCard>
                    )
                })}
            </article>
        </div>
    )
}