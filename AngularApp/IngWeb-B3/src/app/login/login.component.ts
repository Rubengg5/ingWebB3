import {Component, OnInit} from '@angular/core';
import {GoogleLoginProvider, SocialAuthService} from 'angularx-social-login';
import {Router} from '@angular/router';
import { AuthGuardService } from '../services/auth-guard.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  user: gapi.auth2.GoogleUser;

  constructor(private router: Router,
    private authGuardService: AuthGuardService) {
  }

  ngOnInit(): void {
    this.authGuardService.observable().subscribe(user => {
      this.user = user
    });
  }

  loginWithGoogle(): void {
    this.authGuardService.signIn()
  }
}
