import { useEffect, useState } from "react"


export const ItemList = () => {
    const [items, setItems] = useState([])
    // filter for just the user's items? different endpoint?

    const getItems = () => {
        //get then set
    }

    useEffect(() => {
        getItems()
    }, [])

    return (
        <div>
            <h2>Items</h2>
            {items.map((item) => (
                <ItemCard
                    item={item}
                    key={`item-${item.itemId}`}
                ></ItemCard>
            ))}
        </div>
    )
}