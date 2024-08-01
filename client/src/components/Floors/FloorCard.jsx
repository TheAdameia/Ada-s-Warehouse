import { Card, CardBody, CardSubtitle, CardText, CardTitle } from "reactstrap"


export const FloorCard = ({ floor }) => {

    const numberOfItems = floor.items.length

    return (
        <Card color="dark" outline style={{ marginBottom: "4px"}}>
            <CardBody>
                <CardTitle tag="h5">Floor #{floor.floorId}, Warehouse {floor.warehouseId}</CardTitle>
                {floor.isOverloaded == true ? 
                    <CardSubtitle>Capacity reached, {floor.totalWeight} exceeds limit of {floor.maxStorageWeight}</CardSubtitle> :
                    <CardSubtitle>Can hold {floor.remainingStorage} worth of items out of a total of {floor.maxStorageWeight}. The floor is {((floor.totalWeight / floor.maxStorageWeight) * 100).toFixed(2)}% full.</CardSubtitle>
                }
                <CardText>Floor #{floor.floorId} contains {numberOfItems} {numberOfItems === 1 ? "item" : "items"}.</CardText>
            </CardBody>
        </Card>
    )
}