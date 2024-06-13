import { Card, CardBody, CardSubtitle, CardText, CardTitle } from "reactstrap"


export const FloorCard = ({ floor }) => {
    return (
        <Card color="dark" outline style={{ marginBottom: "4px"}}>
            <CardBody>
                <CardTitle tag="h5">Floor {floor.floorId}</CardTitle>
                {floor.isOverloaded == true ? 
                    <CardSubtitle>Capacity reached, {floor.totalWeight} exceeds limit of {floor.maxStorageWeight}</CardSubtitle> :
                    <CardSubtitle>Floor can hold {floor.remainingStorage} worth of items out of a total of {floor.maxStorageWeight}</CardSubtitle>
                }
                <CardText>Floor contains ### items with ### categories</CardText>
            </CardBody>
        </Card>
    )
}