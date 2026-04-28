import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Contact } from './contact';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {

  contact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: '',
    isActive: false
  };

  contacts: Contact[] = [];

  add(form: any) {
    if (form.valid) {
      this.contacts.push({ ...this.contact });
      form.reset();
    }
  }
}