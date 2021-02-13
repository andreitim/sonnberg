[Angular Documentaion](https://angular.io)

## Setup

- `npm install -g @angular/cli`
- `ng new client`
- `ng server`
- `ng add ngx-bootstrap`
- `npm install font-awesome --save`
- `npm install ngx-toastr --save`
- `npm install @angular/animations --save`
- `npm install bootswatch` => bootsrap themes

## Angular Modules

- HttpClientModule - for http requests.

- FormsModule:
        <form #loginForm="ngForm" class="form-inline mt-2 mt-md-0" (ngSubmit)="login()" autocomplete="off">

## Generate Angular Related Tthings.

- `ng generate component -skip-tests` - generates a component: html, css, ts files
  * are destroyed when they are not in use.

- `ng generate service account --skip-tests`
  * a service is a singleton
  * is injectable

- `ng generate service account --skip-tests`  

- `ng generate guard auth --skip-tests`

- `ng generate module shared --flat`

- `ng generate interceptor error --skip-tests`

## Notions

- Two way binding `[(ngModel)]="model.username"`
- From template to the component: `(ngSubmit)="login()"`
- From component to the template: `[ngModel]="model.username"`


#loginForm="ngForm" (ngSubmit)="login()"

(click)="logout()"

*ngIf="loggedIn" // removes element from DOM if condition is false.
*ngFor='let user of users'


`!!user` => turns object into boolean: if user is null it is false otherwise it is true.

`*ngIf="currentUser$ | async"` => async pipe on observables, no need to unsubscribe as it will unsubscribe automatically when component is disposed.