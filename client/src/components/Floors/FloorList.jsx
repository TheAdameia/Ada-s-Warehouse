import { useEffect, useState } from "react"
import { GetAllFloors } from "../../managers/floorManager"
import { FloorCard } from "./FloorCard"
import { GetAllWarehouses } from "../../managers/warehouseManager"


export const FloorList = () => {
    const [floors, setFloors] = useState([])
    const [warehouses, setWarehouses] = useState([])

    const getAndSetWarehouses =() => {
        GetAllWarehouses().then(setWarehouses)
    }

    const getAndSetFloors = () => {
        GetAllFloors().then(setFloors)
    }

    useEffect(() => {
        getAndSetFloors()
        getAndSetWarehouses()
    }, [])

    return (
        <div className="floors-container">
            <h2>Floor Status</h2>
            <label>Warehouse to view:</label>
            <select name="selection" id="selection">
                <option key="0" value="0">
                    All Warehouses
                </option>
                {
                    warehouses.map((warehouse) => {
                        return (
                            <option
                                key={warehouse.warehouseId}
                                value={warehouse.warehouseId}
                            >
                                {warehouse.location}
                            </option>
                        )
                    })
                }
            </select>
            <article className="floors">
                {floors.map((floor) => {
                    return (
                        <FloorCard
                            floor={floor}
                            key={`floor-${floor.floorId}`}
                        ></FloorCard>
                    )
                })}
            </article>
        </div>
    )
}