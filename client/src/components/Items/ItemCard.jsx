import { useNavigate } from "react-router-dom"
import { Button, Card, CardBody, CardSubtitle, CardText, CardTitle } from "reactstrap"
import { DeleteItem } from "../../managers/itemManager"


export const ItemCard = ({ item, getAndSetItems }) => {
    const navigate = useNavigate()

    const handleDelete = (id) => {
        DeleteItem(id).then(() => {
            getAndSetItems()
        })
    }

    const handleEdit = (id) => {
        navigate(`/items/${id}`)
    }

    return (
        <Card color="dark" outline style={{ marginBottom: "4px" }}>
            <CardBody>
                <CardTitle tag="h5">Item {item.itemId}: {item.description}</CardTitle>
                <CardSubtitle>Owner: User #{item.userId}</CardSubtitle>
                <CardText>Weight: {item.weight}</CardText>
                <CardText>Floor: {item.floorId}</CardText>
                <Button
                    onClick={() => handleEdit(item.itemId)}
                >Edit Item</Button>
                <Button
                    onClick={() => handleDelete(item.itemId)}
                >Delete Item</Button>
            </CardBody>
        </Card>
    )
}