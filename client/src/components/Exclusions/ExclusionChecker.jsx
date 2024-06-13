import { useEffect, useState } from "react"
import { GetOneFloor } from "../../managers/floorManager"
import { GetAllExclusions } from "../../managers/exclusionManager"

export const ExclusionChecker = ({ passedItem }) => {
    const [oneFloor, setOneFloor] = useState({})
    const [exclusions, setExclusions] = useState([])

    const getAndSetOneFloor = (passedItem) => {
        const oneFloorId = passedItem.floorId
        GetOneFloor(oneFloorId).then(setOneFloor)
    }

    const getAndSetExclusions =() => {
        GetAllExclusions().then(setExclusions)
    }


    useEffect(() => {
        if (passedItem.floorId != 0){
            getAndSetOneFloor(passedItem)
        }
    }, [passedItem])

    useEffect(() => {
        getAndSetExclusions()
    }, [])

    return (
        <div>
            <div>
            {oneFloor.remainingStorage < passedItem.weight ? "WARNING: maximum weight exceeded" : "weight within capacity"}
            </div>
            <div>

            </div>
        </div>
    )
}

// so IF the item WOULD cause the TOTAL WEIGHT of the FLOOR to exceed its MAXIMUMWEIGHT,
// it should return as rejected.

// Also, IF the item WOULD be on the same FLOOR as an ITEM with a CATEGORY that is EXCLUSIVE to the category of the item,
// it should return as rejected