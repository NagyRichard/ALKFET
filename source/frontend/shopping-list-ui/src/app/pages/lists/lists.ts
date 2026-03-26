import { Component, OnInit, inject } from '@angular/core';
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
      },
      error: () => {
        this.errorMessage = 'Nem sikerült betölteni a listákat.';
        this.isLoading = false;
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
      },
      error: () => {
        this.errorMessage = 'Nem sikerült létrehozni a listát.';
      }
    });
  }
}