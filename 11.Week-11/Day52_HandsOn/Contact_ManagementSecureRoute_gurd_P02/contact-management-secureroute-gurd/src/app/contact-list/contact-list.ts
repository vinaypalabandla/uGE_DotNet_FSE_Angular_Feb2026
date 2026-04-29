import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  imports: [CommonModule,RouterModule],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {

 
  contacts: any[] = [];

  ngOnInit() {
    this.contacts = JSON.parse(localStorage.getItem('contacts') || '[]');

    // Default data if empty
    if (this.contacts.length === 0) {
      this.contacts = [
        { id: 1, name: 'Vinay', phone: '9999999999' },
        { id: 2, name: 'Rahul', phone: '8888888888' }
      ];
      localStorage.setItem('contacts', JSON.stringify(this.contacts));
    }
  }
}
