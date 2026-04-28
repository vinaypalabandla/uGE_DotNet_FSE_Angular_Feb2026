import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Contact } from './contact';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule,CommonModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})

export class App {

  contacts: Contact[] = [];
  form!: FormGroup;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.minLength(10)]],
      isActive: [false]
    });
  }

  add() {
    if (this.form.valid) {
      this.contacts.push(this.form.value as Contact);
      this.form.reset();
    }
  }
}

//Templeate drivemen example logic
// export class App {

//   contact: Contact = {
//     id: 0,
//     name: '',
//     email: '',
//     phone: '',
//     isActive: false
//   };

//   contacts: Contact[] = [];

//   add(form: any) {
//     if (form.valid) {
//       this.contacts.push({ ...this.contact });
//       form.reset();
//     }
//   }
// }