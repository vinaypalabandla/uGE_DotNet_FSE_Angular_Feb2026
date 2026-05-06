import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Contact } from '../../models/contact';
import { ContactService } from '../../services/contact-service';

@Component({
  selector: 'app-contact-form',
  imports: [FormsModule,RouterModule],
  templateUrl: './contact-form.html',
  styleUrl: './contact-form.css',
})
export class ContactForm implements OnInit {

 public data:Contact[] = [];
   
  contact: Contact = { id: 0, name: '', email: '', phone: '' };
  isEdit = false;
  
  constructor(private service:ContactService,private route:ActivatedRoute,private router: Router) {}
 

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.isEdit = true;
      this.service.getContactById(id).subscribe(data => {
        this.contact = data;
      });
    }
  }


  save() {
  if (this.isEdit) {
    this.service.updateContact(this.contact).subscribe({
      next: () => {
        alert("Contact Updated Successfully");
        this.router.navigate(['/']);
      },
      error: () => {
        alert("Update failed");
      }
    });
  } else {
    this.service.addContact(this.contact).subscribe({
      next: () => {
        alert("Contact Added Successfully");
        this.router.navigate(['/']);
      },
      error: () => {
        alert("Add failed");
      }
    });
  }
}



}
