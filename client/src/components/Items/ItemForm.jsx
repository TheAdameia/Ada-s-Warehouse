import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom"
import { Button, FormGroup, Input, Label, Form } from "reactstrap";
import { GetOneItem, PostItem } from "../../managers/itemManager";


export const ItemForm = ({ loggedInUser }) => {
    const [itemDescription, setItemDescription] = useState("")
    const [itemFloor, setItemFloor] = useState(0)
    const [itemWeight, setItemWeight] = useState(0)
    const [itemToEdit, setItemToEdit] = useState()
    const { itemId } = useParams()
    const navigate = useNavigate()

    const handleSubmit = (event) => {
        event.preventDefault()
        const newItem = {
            userId: loggedInUser.id,
            description: itemDescription,
            weight: itemWeight,
            floorId: itemFloor
        }
        PostItem(newItem).then(() => {
            navigate("/items")
        })
    }

    const getAndSetOneItem = (id) => {
        GetOneItem(id).then(setItemToEdit)
    }

    const handleEdit = () => {
        console.log("Quack!!");
    }

    useEffect(() => {
        if (itemId != null) {
            getAndSetOneItem(itemId)
        }
    }, [])

    useEffect(() => {
        if (itemToEdit != null){
            setItemDescription(itemToEdit.description)
            setItemFloor(itemToEdit.floorId)
            setItemWeight(itemToEdit.weight)
        }
    }, [itemToEdit])

    

    return (
        <div className="container">
            { itemId == null ?
            <h4>Create an Item</h4> :
            <h4>Edit your Item</h4>
            }
            <Form>
                <FormGroup>
                    <Label>Item Description</Label>
                    <Input
                        value={itemDescription}
                        type="text"
                        onChange={(e) => {
                            setItemDescription(e.target.value)
                        }}
                    />
                    <Label>Item Weight</Label>
                    <Input
                        value={itemWeight}
                        type="number"
                        onChange={(e) => {
                            setItemWeight(e.target.value)
                        }}
                    />
                    <Label>Item Floor</Label>
                    <Input
                        value={itemFloor}
                        type="number"
                        onChange={(e) => {
                            setItemFloor(e.target.value)
                        }}
                    />
                </FormGroup>
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