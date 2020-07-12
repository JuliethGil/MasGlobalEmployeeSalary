import { Component, Inject, OnInit } from '@angular/core';
import { ApiService } from "./service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public employees: Employee[];
  public identityEmployee;
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

  searchEmployee() {
    this.api
      .getListOfGroup(this.url + "?identity=" + this.identityEmployee)
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
  RoleDescription: string,
  HourlySalary: number,
  MonthlySalary: number,
  AnnualSalary: number
}
