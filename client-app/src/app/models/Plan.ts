export interface IPlan {
    id: string;
    name: string;
    serviceCount: string;
    description: string;
    duration: string;
    isSelected:boolean;
    planMonyUnitDTO: IPlanMonyUnitDTO[];

}


export interface IPlanMonyUnitDTO {
    price: string;
    monyName: string;
}