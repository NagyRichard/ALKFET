import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ShoppingList } from '../models/shopping-list.model';
import { ShoppingItem } from '../models/shopping-item.model';

@Injectable({
  providedIn: 'root'
})
export class ShoppingApiService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = environment.apiBaseUrl;

  getLists(): Observable<ShoppingList[]> {
    return this.http.get<ShoppingList[]>(`${this.baseUrl}/lists`);
  }

  createList(name: string): Observable<ShoppingList> {
    return this.http.post<ShoppingList>(`${this.baseUrl}/lists`, { name });
  }

  deleteList(listId: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/lists/${listId}`);
  }

  getItems(listId: string): Observable<ShoppingItem[]> {
    return this.http.get<ShoppingItem[]>(`${this.baseUrl}/lists/${listId}/items`);
  }

  createItem(
    listId: string,
    payload: {
      name: string;
      quantity: number;
      unit: string;
      category: string;
      note?: string;
    }
  ): Observable<ShoppingItem> {
    return this.http.post<ShoppingItem>(
      `${this.baseUrl}/lists/${listId}/items`,
      payload
    );
  }

  toggleItem(listId: string, itemId: string): Observable<void> {
    return this.http.patch<void>(
      `${this.baseUrl}/lists/${listId}/items/${itemId}/toggle`,
      {}
    );
  }

  deleteItem(listId: string, itemId: string): Observable<void> {
    return this.http.delete<void>(
      `${this.baseUrl}/lists/${listId}/items/${itemId}`
    );
  }
}