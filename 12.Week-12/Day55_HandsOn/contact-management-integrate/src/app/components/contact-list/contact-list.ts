import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../services/contact-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './contact-list.html'
})
export class ContactList implements OnInit {

  data: any[] = [];

  newContact: any = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    categoryId: 0
  };

 searchId: number | null = null; 
selectedContact: any;

  constructor(private service: ContactService) {}

  ngOnInit(): void {
   
  }
//Used For Get Contacts
  getContacts() {
    this.service.getContacts().subscribe(res => {
      this.data = res;
    });
  }

 //Add Contacts
  addContact() {
    this.service.addContact(this.newContact).subscribe(() => {
      alert("Contact Added");
      this.getContacts();
      this.resetForm();
    });
  }
//Edit Contacts
  editContact(c: any) {
    this.newContact = { ...c };
  }

  //Update Contacts
  updateContact() {
    this.service.updateContact(this.newContact).subscribe(() => {
      alert("Updated Successfully");
      this.getContacts();
      this.resetForm();
    });
  }

 //Delete Contacts
  deleteContact(id: number) {
    if (!id) {
      alert("Invalid ID");
      return;
    }

    this.service.deleteContact(id).subscribe(() => {
      alert("Deleted Successfully");
      this.getContacts();
    });
  }
//get contact by id
getContactById() {

  if (!this.searchId || this.searchId <= 0) {
    alert("Enter valid ID");
    return;
  }

  this.service.getContactById(this.searchId).subscribe({
    next: (res) => {
      console.log("Found:", res);

      // only show one record
      this.data = [res];
    },
    error: () => {
      alert("Contact not found");

      //clear table if not found
      this.data = [];
    }
  });
}
  resetForm() {
    this.newContact = {
      contactId: 0,
      name: '',
      email: '',
      phone: '',
      categoryId: 0
    };
  }
}