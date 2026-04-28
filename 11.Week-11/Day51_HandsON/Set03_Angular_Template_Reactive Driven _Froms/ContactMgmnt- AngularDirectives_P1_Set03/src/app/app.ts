import { Component, signal } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ContactList } from './contact-list/contact-list';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,RouterLink,ContactList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('ContactManagement-route');
}
