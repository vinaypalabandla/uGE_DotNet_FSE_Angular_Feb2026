import { Routes } from '@angular/router';
import { ContactList } from './components/contact-list/contact-list';
import { ContactForm } from './components/contact-form/contact-form';
import { ContactDetails } from './components/contact-details/contact-details';

export const routes: Routes = [
      { path: '', component: ContactList },
  { path: 'add', component: ContactForm },
  { path: 'edit/:id', component: ContactForm },
  { path: 'details/:id', component: ContactDetails }
];
