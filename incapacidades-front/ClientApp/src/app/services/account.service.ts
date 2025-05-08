import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { IUsuario } from '../interfaces/IUsuario';

@Injectable({ providedIn: 'root' })
export class AccountService {
  //private userSubject: BehaviorSubject<LoginModel>;
  private userSubject: BehaviorSubject<IUsuario>;
  //public user: Observable<LoginModel>;
  public user: Observable<IUsuario>;
  
  token;
    constructor(
        private router: Router,
      private http: HttpClient
    ) {
      //this.userSubject = new BehaviorSubject<LoginModel>(JSON.parse(localStorage.getItem('user')));
      this.userSubject = new BehaviorSubject<IUsuario>(JSON.parse(localStorage.getItem('usuario')));
      this.user = this.userSubject.asObservable();
    }

  //public get userValue(): LoginModel {
  public get userValue(): IUsuario {
        return this.userSubject.value;
  }

  //IniciarSesion(username, password, datosUsuario) {
  IniciarSesion(datosUsuario, datosPerfil) {
    //return this.http.post<LoginModel>(`${environment.apiUrl}/users/authenticate`, { username, password, datosUsuario })
    return this.http.post<IUsuario>(`${environment.apiUrl}/users/authenticate`, {datosUsuario })
            .pipe(map(user => {
              //localStorage.setItem('user', JSON.stringify(user));
              localStorage.setItem('usuario', JSON.stringify(datosUsuario));
              localStorage.setItem('perfil', JSON.stringify(datosPerfil));
              // console.log('datosUsuario');
              // console.log(datosUsuario);

                this.userSubject.next(user);
                return user;
            }));
  }
    
    CerrarSesion() {
      //localStorage.removeItem('user');
      localStorage.removeItem('usuario');
      localStorage.removeItem('perfil');
      localStorage.removeItem('complementario');
      this.userSubject.next(null);
      this.router.navigate(['/account/login']);
      
    }

}
