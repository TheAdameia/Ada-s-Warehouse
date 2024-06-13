import { useEffect, useState } from "react"
import { GetAllFloors } from "../../managers/floorManager"
import { FloorCard } from "./FloorCard"


export const FloorList = () => {
    const [floors, setFloors] = useState([])

    const getAndSetFloors = () => {
        GetAllFloors.then(setFloors)
    }

    useEffect(() => {
        getAndSetFloors()
    }, [])

    return (
        <div className="floors-container">
            <h2>Floor Status</h2>
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