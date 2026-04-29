import { Component, signal } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { AuthService } from './auth-service';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet,RouterModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
      constructor(public authService: AuthService) {}

  toggleLogin() {
    if (this.authService.isLoggedIn) {
      this.authService.logout();
    } else {
      this.authService.login();
    }
  }
}
