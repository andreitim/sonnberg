import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';
  private currentUserSource = new ReplaySubject<User | null>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {
    this.currentUserSource.next(null);
  }

  register(model: any) {
    return this.http.post<User>(this.baseUrl + `account/register`, model)
                    .pipe(map(user => {
                      this.updateCurrentUser(user);
                    }));
  }

  login(model: User) {
    return this.http.post<User>(this.baseUrl + `account/login`, model)
                    .pipe(map(user => {
                      this.updateCurrentUser(user);
                    }));
  }

  private updateCurrentUser(user: User) {
    if (user) {
      localStorage.setItem('user', JSON.stringify(user));
    }

    this.currentUserSource.next(user);
  }

  restoreCurrentUser() {
    const userJson = localStorage.getItem('user');

    if (userJson != null)
    {
      const user: User = JSON.parse(userJson);
      this.currentUserSource.next(user);  
    }
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
