import { useEffect, useState } from "react"
import { GetOneFloor } from "../../managers/floorManager"
import { GetAllExclusions } from "../../managers/exclusionManager"

export const ExclusionChecker = ({SuggestedItem}) => {
    const [oneFloor, setOneFloor] = useState({})
    const [exclusions, setExclusions] = useState([])

    const getAndSetOneFloor = (SuggestedItem) => {
        GetOneFloor(SuggestedItem.floorId).then(setOneFloor)
    }

    const getAndSetExclusions =() => {
        GetAllExclusions().then(setExclusions)
    }


    useEffect(() => {
        getAndSetOneFloor(SuggestedItem)
    }, [SuggestedItem])

    useEffect(() => {
        getAndSetExclusions()
    }, [])

    return (
        <div>
            <div>
            {(oneFloor.totalWeight < oneFloor.remainingStorage + SuggestedItem.weight) ? "bad weight" : "good weight"}
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