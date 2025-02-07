import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../_modules/user';
import { map } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
   baseUrl = 'https://localhost:7087/api/';
   currentUser = signal<User | null>(null);

   login(model: any){
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map(user => {
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    )
  }

   register(model: any){
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user => { //con el map transformamos nuestra información
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
        return user;
      })
    )
  }
  


  logOut(){
  localStorage.removeItem('user');
  this.currentUser.set(null);
  }
}


