export interface ShoppingItem {
  id: string;
  listId: string;
  name: string;
  quantity: number;
  unit: string;
  category: string;
  isPurchased: boolean;
  note?: string;
  createdAt: string;
  updatedAt: string;
}