export interface Order {
    id: number;
    bondAsset: string;
    index: string;
    quantity: number;
    status: string;
    unitPrice: number;
  }
  
  export interface OrderUser {
    userId: string;
    userName: string;
    email: string;
    balance: number;
  }
  
  export interface OrderResponse {
    items: Order[];
    user: OrderUser;
    totalElements: number;
    pageNumber: number;
    pageSize: number;
  }