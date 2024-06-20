import { useEffect, useState } from "react"
import { ItemCard } from "./ItemCard"
import { GetUserItems } from "../../managers/itemManager"
import "./ItemList.css"


export const ItemList = ({ loggedInUser }) => {
    const [items, setItems] = useState([])

    const getAndSetItems = () => {
        GetUserItems(loggedInUser.id).then(setItems)
    }

    useEffect(() => {
        getAndSetItems()
    }, [])

    return (
        <div className="item-container">
            <h2>My Items</h2>
            <article className="item-article">
                {items.map((item) => {
                    return (
                        <ItemCard
                            item={item}
                            key={`item-${item.itemId}`}
                            getAndSetItems={getAndSetItems}
                        ></ItemCard>
                    )
                })}
            </article>
        </div>
    )
}