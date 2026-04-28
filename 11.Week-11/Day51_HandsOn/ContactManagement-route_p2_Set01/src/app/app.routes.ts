import { Routes } from '@angular/router';
import { ContactDetail } from './contact-detail/contact-detail';
import { ContactList } from './contact-list/contact-list';
import { AddContact } from './add-contact/add-contact';

export const routes: Routes = [
     { path: '', component: ContactList },
  { path: 'contacts', component: ContactList },
  { path: 'add-contact', component: AddContact },
  { path: 'contact/:id', component: ContactDetail},
  
];
