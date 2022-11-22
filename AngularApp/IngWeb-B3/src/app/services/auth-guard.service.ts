import {Injectable} from '@angular/core';
import {SocialAuthService, SocialUser} from 'angularx-social-login';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {Observable, ReplaySubject} from 'rxjs';
import {map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

    private auth2: gapi.auth2.GoogleAuth;
    private subject = new ReplaySubject<gapi.auth2.GoogleUser>(1)

  constructor() {
    gapi.load('auth2', () => {
        this.auth2 = gapi.auth2.init({
            client_id: '182737891985-bhlpao31dj89qgu93i4pp3die544nomb.apps.googleusercontent.com'
        })
      })
  }

  public signIn(){
    this.auth2.signIn({
        scope: 'https://www.googleapis.com/auth/gmail.readonly'
    }).then(user => {
        this.subject.next(user)
    }).catch(() => {
        //this.subject.next("")
    })
  }

  public signOut(){
    this.auth2.signOut()
    .then(() => {
        //this.subject.next("")
    })
  }

  public observable(): Observable<gapi.auth2.GoogleUser>{
    return this.subject.asObservable()
  }
}