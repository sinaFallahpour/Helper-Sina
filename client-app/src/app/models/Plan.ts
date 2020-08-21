export interface IPlan {
    id: string;
    name: string;
    serviceCount: string;
    description: string;
    duration: string;
    planMonyUnitDTO: IPlanMonyUnitDTO[];

}


export interface IPlanMonyUnitDTO {
    price: string;
    monyName: string;
}