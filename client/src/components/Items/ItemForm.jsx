import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom"
import { Button, FormGroup, Input, Label, Form } from "reactstrap";
import { EditItem, GetOneItem, PostItem } from "../../managers/itemManager";
import { ExclusionChecker } from "../Exclusions/ExclusionChecker";
import { GetAllCategories } from "../../managers/categoryManager"
import "./ItemForm.css"

export const ItemForm = ({ loggedInUser }) => {
    const [itemToEdit, setItemToEdit] = useState()
    const [passedItem, setPassedItem] = useState({
        description: "", 
        weight: 0, 
        floorId: 0,
        userId: 0,
        itemId: 0,
        itemCategory: []})
    const [categories, setCategories] = useState([])
    const [selectedCategories, setSelectedCategories] = useState([])
    const { itemId } = useParams()
    const navigate = useNavigate()

    const handleSubmit = (event) => {
        event.preventDefault()
        const newItem = {...passedItem,
            itemCategory: selectedCategories.map(c => ({
                categoryId: c.categoryId
            }))
        }
        newItem.userId = loggedInUser.id
        PostItem(newItem).then(() => {
            navigate("/items")
        })
    }

    const getAndSetOneItem = (id) => {
        GetOneItem(id).then(setItemToEdit)
        // ok, now that we have the item, we go ahead and get the categories, 
    }

    const getAndSetCategories = () => {
        GetAllCategories().then(setCategories)
    }

    const handleEdit = (event) => {
        event.preventDefault()
        const editedItem = {...passedItem,
            itemCategory: selectedCategories.map(c => ({
                categoryId: c.categoryId
            }))
        }
        EditItem(editedItem).then(() => {
            navigate("/items")
        })
    }

    const handleCheckboxChange = (e, category) => {
        const { checked } = e.target
        if (checked) {
            setSelectedCategories([...selectedCategories, category])
        } else {
            setSelectedCategories(selectedCategories.filter(c => c.categoryId !== category.categoryId))
        }
    }

    useEffect(() => {
        if (itemId != null) {
            getAndSetOneItem(itemId)
        }
    }, [itemId])

    useEffect(() => {
        getAndSetCategories()
    }, [])

    useEffect(() => {
        if (itemToEdit){
            const itemCopy = {...passedItem}
            itemCopy.description = itemToEdit.description
            itemCopy.floorId = itemToEdit.floorId
            itemCopy.weight = itemToEdit.weight
            itemCopy.userId = itemToEdit.userId
            itemCopy.itemId = itemToEdit.itemId
            itemCopy.itemCategory = itemToEdit.itemCategory
            setPassedItem(itemCopy)
        }
    }, [itemToEdit])

    useEffect(() => {
        let preexistingCategory = []
        if (itemToEdit && itemToEdit.itemCategory){
            preexistingCategory = itemToEdit.itemCategory.map(ic => ic.category)
        }

        if (preexistingCategory != [])
            {
                setSelectedCategories(preexistingCategory)
            }
    }, [itemToEdit])

    return (
        <div className="container">
            { itemId == null ?
            <h4>Create an Item</h4> :
            <h4>Edit your Item</h4>
            }
            <Form>
                <FormGroup className="form-group">
                    <Label>Item Description</Label>
                    <Input
                        value={passedItem.description}
                        type="text"
                        onChange={(e) => {
                            const itemCopy = {...passedItem}
                            itemCopy.description = e.target.value
                            setPassedItem(itemCopy)
                        }}
                    />
                    <Label>Item Weight</Label>
                    <Input
                        value={passedItem.weight}
                        type="number"
                        onChange={(e) => {
                            const itemCopy = {...passedItem}
                            itemCopy.weight = e.target.value
                            setPassedItem(itemCopy)
                        }}
                    />
                    <Label>Item Floor</Label>
                    <Input
                        value={passedItem.floorId}
                        type="number"
                        onChange={(e) => {
                            const itemCopy = {...passedItem}
                            itemCopy.floorId = e.target.value
                            setPassedItem(itemCopy)
                        }}
                    />
                    <Label>Category Selection</Label>
                    <div className="checkbox-group">
                    {
                        categories.map((category) => {
                            let hasDefault = false
                            for (const single of selectedCategories) {
                                if (category.categoryId == single.categoryId){
                                    hasDefault = true
                                }
                            }
                            return (
                                <div key={category.categoryId}>
                                    <Input
                                        type="checkbox"
                                        value={category.name}
                                        id={category.categoryId}
                                        name="category"
                                        onChange={(event) => handleCheckboxChange(event, category)}
                                        checked={hasDefault}
                                    />
                                    <label htmlFor={category.categoryId}>{category.name}</label>
                                </div>
                            )
                        })
                    }
                    </div>
                </FormGroup>
                <ExclusionChecker
                    passedItem={passedItem}
                    selectedCategories={selectedCategories}
                />
                <>
                    { itemId == null ?
                    <Button
                        onClick={handleSubmit}
                    >Submit Item</Button> :
                    <Button
                        onClick={handleEdit}
                    >Edit Item</Button>}
                </>
            </Form>
        </div>
    )
}