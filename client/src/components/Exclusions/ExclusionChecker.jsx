import { useEffect, useState } from "react"
import { GetOneFloor } from "../../managers/floorManager"
import { GetAllExclusions } from "../../managers/exclusionManager"
import { GetFloorCategories } from "../../managers/categoryManager"
import "./Exclusion.css"

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
                    break
                } else if (list1Ids.has(relation.categoryId2) && list2Ids.has(relation.categoryId1)) {
                    setExclusionsOk(false)
                    break
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
                {oneFloor.remainingStorage < passedItem.weight ? <div className="warning-message">WARNING: maximum weight exceeded</div> : <div className="safe-message">weight within capacity</div>}
            </div>
            <div>
                {exclusionsOk == true ? <div className="safe-message">No exclusions</div> : <div className="warning-message">WARNING: MUTUALLY INCOMPATIBLE CATEGORIES ON FLOOR</div>}
            </div>
        </div>
    )
}
