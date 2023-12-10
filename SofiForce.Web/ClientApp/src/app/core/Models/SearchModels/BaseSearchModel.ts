export class BaseSearchModel {
    Take: number | 30;
    Skip: number;
    Term: string;
    TermBy:string;
    FilterBy: FilterBy[];
    SortBy: SortBy;
}

export interface FilterBy {
    Property: string;
    Operand: string;
    Value: any;
}

export interface SortBy {
    Property: string;
    Order: string;
}