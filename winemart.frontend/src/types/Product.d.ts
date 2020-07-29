export interface IProduct {
    id: number;
    name: string;
    description: string;
    price: number;
    isTaxable: boolean;
    isArchived: boolean;
    dateCreated: Date;
    dateUpdated: Date;
  }
