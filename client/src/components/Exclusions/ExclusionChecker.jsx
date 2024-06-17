import { useEffect, useState } from "react"
import { GetOneFloor } from "../../managers/floorManager"
import { GetAllExclusions } from "../../managers/exclusionManager"
import { GetFloorCategories } from "../../managers/categoryManager"

export const ExclusionChecker = ({ passedItem, selectedCategories }) => { //selectedCategories is list 1
    const [oneFloor, setOneFloor] = useState({})
    const [exclusions, setExclusions] = useState([])                   // list 3, per design
    const [floorItemCategories, setFloorItemCategories] = useState([]) // list 2, per design
    const [exclusionsOk, setExclusionsOk] = useState(true)

    const getAndSetOneFloor = (passedItem) => {
        const oneFloorId = passedItem.floorId
        GetOneFloor(oneFloorId).then(setOneFloor)
    }

    const getAndSetExclusions = () => {
        GetAllExclusions().then(setExclusions)
    }

    const CheckForExclusions = (list1, list2, exclusions) => {
        if (list1){
            const list1Ids = new Set(list1.map(c => c.categoryId))
            const list2Ids = new Set(list2.map(c => c.categoryId))

            for (const relation of exclusions) {
                if (list1Ids.has(relation.categoryId1) && list2Ids.has(relation.categoryId2)) {
                    setExclusionsOk(false)
                } else if (list1Ids.has(relation.categoryId2) && list2Ids.has(relation.categoryId1)) {
                    setExclusionsOk(false)
                } else {
                    setExclusionsOk(true)
                }
            }
        }
    }
    
    const getAndSetFloorItemCategories = (id) => {
        GetFloorCategories(id).then(setFloorItemCategories)
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
        if (oneFloor.floorId) {
            getAndSetFloorItemCategories(oneFloor.floorId)
        }
        
    }, [oneFloor])

    useEffect(() => {
        CheckForExclusions(selectedCategories, floorItemCategories, exclusions)
    }, [selectedCategories, floorItemCategories, exclusions])

    return (
        <div>
            <div>
                {oneFloor.remainingStorage < passedItem.weight ? "WARNING: maximum weight exceeded" : "weight within capacity"}
            </div>
            <div>
                {exclusionsOk == true ? "No exclusions": "WARNING: MUTUALLY INCOMPATIBLE CATEGORIES ON FLOOR"}
            </div>
        </div>
    )
}