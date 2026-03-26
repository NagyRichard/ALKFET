import { Routes } from '@angular/router';
import { Lists } from './pages/lists/lists';
import { ListDetails } from './pages/list-details/list-details';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'lists',
    pathMatch: 'full'
  },
  {
    path: 'lists',
    component: Lists
  },
  {
    path: 'lists/:id',
    component: ListDetails
  }
];