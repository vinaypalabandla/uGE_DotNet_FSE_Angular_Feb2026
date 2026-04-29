import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-contact',
   imports: [FormsModule],
  standalone: true,
  templateUrl: './add-contact.html'
})
export class AddContactComponent {

  contact = {
    name: '',
    phone: ''
  };

  constructor(private router: Router) {}

  addContact(form: any) {

    if (form.valid) {

      // Get existing contacts
      let contacts = JSON.parse(localStorage.getItem('contacts') || '[]');

      // Add new contact
      contacts.push({
        id: contacts.length + 1,
        name: this.contact.name,
        phone: this.contact.phone
      });

      // Save back
      localStorage.setItem('contacts', JSON.stringify(contacts));

      alert("Contact Added Successfully!");

      // Redirect
      this.router.navigate(['/contacts']);
    }
  }
}