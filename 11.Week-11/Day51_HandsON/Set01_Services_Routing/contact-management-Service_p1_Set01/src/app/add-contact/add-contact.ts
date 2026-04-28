import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Contact } from '../contact';
import { ContactService } from '../contact-service';

@Component({
  selector: 'app-add-contact',
  imports: [CommonModule, FormsModule],
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
  constructor(private service: ContactService) {}

  public add() {
    this.service.addContact(this.contact);
    this.contact = { id: 0, name: '', email: '', phone: '' };
  }
}
