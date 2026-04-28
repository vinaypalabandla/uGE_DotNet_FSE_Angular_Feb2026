import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
//import { RouterLink } from '@angular/router';
//import { ContactService } from '../contact-service';
import { Contact } from '../contact';
@Component({
  selector: 'app-contact-list',
  imports: [CommonModule],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {
  contacts: Contact[] = [
    { id: 1, name: 'Vinay', email: 'vinay@gmail.com', phone: '1111111111', isActive: true },
    {id: 2, name: 'Kumar', email: 'kumar@gmail.com', phone: '2222222222', isActive: false }
  ];
  
}
