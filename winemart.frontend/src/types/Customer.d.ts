export interface ICustomer {
    id: number;
    dateCreated: Date;
    dateUpdated?: Date;
    firstName: string;
    lastName: string;
    address: ICustomerAddress;
  }
  
  export interface ICustomerAddress {
    id: number;
    dateCreated: Date;
    dateUpdated?: Date;
    addressLine1: string;
    addressLine2: string;
    city: string;
    state: string;
    postalCode: string;
    country: string;
  }