import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom"
import { Button, FormGroup, Input, Label, Form } from "reactstrap";


export const ItemForm = ({ itemToEdit }) => {
    const [itemDescription, setItemDescription] = useState("")
    const [itemFloor, setItemFloor] = useState(0)
    const [itemWeight, setItemWeight] = useState(0)
    const { determinant } = useParams()
    const navigate = useNavigate()

    const handleSubmit = () => {
        console.log("Quack!");
    }

    const handleEdit = () => {
        console.log("Quack!!");
    }

    // if itemToEdit != null... set all the states
    return (
        <div className="container">
            { determinant == null ?
            <h4>Create an Item</h4> :
            <h4>Edit your Item</h4>
            }
            <Form>
                <FormGroup>
                    <Label>Item Description</Label>
                    <Input
                        type="text"
                        onChange={(e) => {
                            setItemDescription(e.target.value)
                        }}
                    />
                    <Label>Item Weight</Label>
                    <Input
                        type="integer"
                        onChange={(e) => {
                            setItemWeight(e.target.value)
                        }}
                    />
                    <Label>Item Floor</Label>
                    <Input
                        type="integer"
                        onChange={(e) => {
                            setItemFloor(e.target.value)
                        }}
                    />
                </FormGroup>
                <>
                    { determinant == null ?
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