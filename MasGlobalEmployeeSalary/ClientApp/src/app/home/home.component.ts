import { Component, Inject, OnInit } from '@angular/core';
import { ApiService } from "./service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  public employees: Employee[];
  url;

  constructor(private api: ApiService, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'api/employee';
  }

  ngOnInit() {
    this.api
      .getListOfGroup(this.url)
      .subscribe(
        data => {
          console.log(data);
          this.employees = data;
        },
        err => {
          console.log(err);
        }
      );
  }
}

interface Employee {
  Id: number,
  Name: string,
  ContractTypeName: string,
  RoleId: number,
  RoleName: string,
  roleDescription: string,
  hourlySalary: number,
  monthlySalary: number
}
