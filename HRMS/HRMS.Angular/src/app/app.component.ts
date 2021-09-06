import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { authConfig } from './sso.config';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HRMS';

  constructor(private oauthService:OAuthService) {
    this.ConfigureSSO();
  }

  ConfigureSSO() {
    this.oauthService.configure(authConfig);
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }

  Login() {
    this.oauthService.initCodeFlow();
  }

  Logout() {
    this.oauthService.logOut();
  }
}
