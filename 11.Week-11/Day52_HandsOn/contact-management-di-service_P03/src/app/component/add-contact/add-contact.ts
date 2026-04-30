import { Component } from '@angular/core';
import { ContactService } from '../../services/contact-service';
import { Contact } from '../../models/contact';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-contact',
  imports: [FormsModule,CommonModule],
  templateUrl: './add-contact.html',
  styleUrl: './add-contact.css',
})
export class AddContact {
   contact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };

  constructor(private contactService: ContactService) {}

  addContact() {

  this.contact.id = Date.now();

  this.contactService.addContact(this.contact);

  alert("Contact Added!");

  //  refresh 
  this.contactService.getContacts();

  // reset
  this.contact = { id: 0, name: '', email: '', phone: '' };
}
}
