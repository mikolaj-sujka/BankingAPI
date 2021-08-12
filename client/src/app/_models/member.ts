import { CreditCard } from "./creditCard";

export interface Member{
    id: number;
    username: string;
    firstName: string;
    lastName: string;
    email: string;
    postalCode: string;
    city: string;
    country: string;
    dateOfBirth: Date;
    creditCard: CreditCard;
}
