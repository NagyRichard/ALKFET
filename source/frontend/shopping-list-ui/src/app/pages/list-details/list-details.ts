import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ShoppingApiService } from '../../services/shopping-api.service';
import { ShoppingItem } from '../../models/shopping-item.model';

@Component({
  selector: 'app-list-details',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './list-details.html',
  styleUrl: './list-details.css'
})
export class ListDetails implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly shoppingApi = inject(ShoppingApiService);

  listId = '';
  items: ShoppingItem[] = [];
  isLoading = false;
  errorMessage = '';

  newItem = {
    name: '',
    quantity: 1,
    unit: 'db',
    category: 'Other',
    note: ''
  };

  ngOnInit(): void {
    this.listId = this.route.snapshot.paramMap.get('id') ?? '';
    this.loadItems();
  }

  loadItems(): void {
    if (!this.listId) {
      this.errorMessage = 'Hiányzó listaazonosító.';
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';

    this.shoppingApi.getItems(this.listId).subscribe({
      next: (items) => {
        this.items = items;
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'Nem sikerült betölteni a tételeket.';
        this.isLoading = false;
      }
    });
  }

  createItem(): void {
    const trimmedName = this.newItem.name.trim();

    if (!trimmedName) {
      return;
    }

    this.shoppingApi.createItem(this.listId, {
      name: trimmedName,
      quantity: this.newItem.quantity,
      unit: this.newItem.unit,
      category: this.newItem.category,
      note: this.newItem.note.trim() || undefined
    }).subscribe({
      next: () => {
        this.newItem = {
          name: '',
          quantity: 1,
          unit: 'db',
          category: 'Other',
          note: ''
        };
        this.loadItems();
      },
      error: () => {
        this.errorMessage = 'Nem sikerült hozzáadni a tételt.';
      }
    });
  }

  toggleItem(itemId: string): void {
    this.shoppingApi.toggleItem(this.listId, itemId).subscribe({
      next: () => {
        this.loadItems();
      },
      error: () => {
        this.errorMessage = 'Nem sikerült módosítani a tétel állapotát.';
      }
    });
  }

  deleteItem(itemId: string): void {
    this.shoppingApi.deleteItem(this.listId, itemId).subscribe({
      next: () => {
        this.loadItems();
      },
      error: () => {
        this.errorMessage = 'Nem sikerült törölni a tételt.';
      }
    });
  }
}