import { useEffect, useState } from "react"
import { GetOneFloor } from "../../managers/floorManager"
import { GetAllExclusions } from "../../managers/exclusionManager"

export const ExclusionChecker = ({ passedItem, selectedCategories }) => {
    const [oneFloor, setOneFloor] = useState({})
    const [exclusions, setExclusions] = useState([])
    const [floorItemCategories, setFloorItemCategories] = useState([])

    const getAndSetOneFloor = (passedItem) => {
        const oneFloorId = passedItem.floorId
        GetOneFloor(oneFloorId).then(setOneFloor)
    }

    const getAndSetExclusions = () => {
        GetAllExclusions().then(setExclusions)
    }

    // const CheckForExclusions = () => {
    //     console.log("Quack!");
    // }
    
    const createFloorItemCategories = () => {
        const array = []
        for (const singleCategory of oneFloor.items.itemCategory.category) {
            array.push(singleCategory)
        }
        setFloorItemCategories(array)
    }

    useEffect(() => {
        if (passedItem.floorId != 0){
            getAndSetOneFloor(passedItem)
        }
    }, [passedItem])

    useEffect(() => {
        getAndSetExclusions()
    }, [])

    useEffect(() => {
        createFloorItemCategories()
    }, [oneFloor])

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

// Also, IF the item WOULD be on the same FLOOR as an ITEM with a CATEGORY that is EXCLUSIVE to the category of the item,
// it should return as rejected

// I am going to need to add DTOs for Floor if this is to function as expected. Needs to be fully expanded.