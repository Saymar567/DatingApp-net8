import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent implements OnInit{
  http = inject(HttpClient);
  registerMode = false;
  users: any; //this is a property and want to pass it to child component

  ngOnInit(): void {
    this.getUsers();
  }

  registerToggle(){
    this.registerMode = !this.registerMode
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }

  getUsers(){
    this.http.get('https://localhost:7087/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: ()=> console.log('Request has completed')
    })
}
}
