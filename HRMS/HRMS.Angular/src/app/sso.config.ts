import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
  issuer: 'https://localhost:4800',
  redirectUri: window.location.origin,
  clientId: 'Angular',
  dummyClientSecret: '49C1A7E1-0C79-4A89-A3D6-A37998FB86B0',
  responseType: 'code',
  scope: 'openid profile email FrontScope',
  showDebugInformation: true
}
