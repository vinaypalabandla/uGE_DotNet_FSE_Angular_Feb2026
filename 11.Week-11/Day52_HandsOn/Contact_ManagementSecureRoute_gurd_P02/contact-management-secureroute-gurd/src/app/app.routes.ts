import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactList } from './contact-list/contact-list';
import { AuthGuard } from './authgurd-gurd-guard';
import { ContactDetails } from './contact-details/contact-details';
import { AddContactComponent } from './add-contact/add-contact';

export const routes: Routes = [

  { path: 'contacts', component: ContactList },

  { 
    path: 'add-contact', 
    component: AddContactComponent ,
    canActivate: [AuthGuard]
  },

  { 
    path: 'contact/:id', 
    component: ContactDetails,
    canActivate: [AuthGuard]
  },

  { path: '', redirectTo: 'contacts', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}