import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ShoppingApiService } from '../../services/shopping-api.service';
import { ShoppingList } from '../../models/shopping-list.model';

@Component({
  selector: 'app-lists',
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './lists.html',
  styleUrl: './lists.css'
})
export class Lists implements OnInit {
  private readonly shoppingApi = inject(ShoppingApiService);
  private readonly cdr = inject(ChangeDetectorRef);

  lists: ShoppingList[] = [];
  newListName = '';
  isLoading = false;
  errorMessage = '';

  ngOnInit(): void {
    this.loadLists();
  }

  loadLists(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.shoppingApi.getLists().subscribe({
      next: (lists) => {
        this.lists = lists;
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: () => {
        this.errorMessage = 'Nem sikerült betölteni a listákat.';
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  createList(): void {
    const trimmedName = this.newListName.trim();

    if (!trimmedName) {
      return;
    }

    this.shoppingApi.createList(trimmedName).subscribe({
      next: () => {
        this.newListName = '';
        this.loadLists();
        this.cdr.detectChanges();
      },
      error: () => {
        this.errorMessage = 'Nem sikerült létrehozni a listát.';
        this.cdr.detectChanges();
      }
    });
  }
  
  deleteList(listId: string): void {
  this.shoppingApi.deleteList(listId).subscribe({
    next: () => {
      // 🔥 azonnali UI frissítés
      this.lists = this.lists.filter(l => l.id !== listId);
      this.cdr.detectChanges();
    },
    error: () => {
      this.errorMessage = 'Nem sikerült törölni a listát.';
      this.cdr.detectChanges();
    }
  });
}
}