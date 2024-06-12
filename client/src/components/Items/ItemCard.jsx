import { Button, Card, CardBody, CardSubtitle, CardText, CardTitle } from "reactstrap"


export const ItemCard = ({ item }) => {
    return (
        <Card color="dark" outline style={{ marginBottom: "4px" }}>
            <CardBody>
                <CardTitle tag="h5">Item {item.itemId}: {item.description}</CardTitle>
                <CardSubtitle>Owner: User #{item.userId}</CardSubtitle>
                <CardText>{item.weight}</CardText>
                <Button>Placeholder!</Button>
            </CardBody>
        </Card>
    )
}