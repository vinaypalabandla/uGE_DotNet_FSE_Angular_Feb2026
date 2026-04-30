import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ContactDetail } from './component/contact-detail/contact-detail';
import { AddContact } from './component/add-contact/add-contact';
import { ContactListComponent } from './component/contact-list/contact-list';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,ContactDetail,AddContact,ContactListComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('contact-management-di-service');
}
