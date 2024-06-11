import { useEffect, useState } from "react"


export const FloorList = () => {
    const [floors, setFloors] = useState([])

    const getAllFloors = () => {
        //get floors then set floors
    }

    useEffect(() => {
        getAllFloors()
    }, [])

    return (
        <div>
            
        </div>
    )
}