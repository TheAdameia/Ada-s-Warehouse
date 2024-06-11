import { Button, Card, CardBody, CardSubtitle, CardText, CardTitle } from "reactstrap"


export const ItemCard = ({ item }) => {
    return (
        <Card color="dark" outline style={{ marginBottom: "4px" }}>
            <CardBody>
                <CardTitle tag="h5">{item.description}</CardTitle>
                <CardSubtitle></CardSubtitle>
                <CardText></CardText>
                <Button></Button>
            </CardBody>
        </Card>
    )
}