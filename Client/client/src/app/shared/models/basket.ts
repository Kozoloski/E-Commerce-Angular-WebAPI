import * as cuid from "cuid";

export interface BasketItem {
    id: number;
    plantName: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    category: string;
    type: string;
}

export interface Basket {
    id:string;
    items: BasketItem[];
}

export class Basket implements Basket {
    id = cuid();
    items: BasketItem[] = [];

}  

export interface BasketTotals {
    shipping: number;
    subtotal: number;
    total: number;
}

