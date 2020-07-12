import { Component, Inject, OnInit } from '@angular/core';
import { ApiService } from "./service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public employees: Employee[];
  public identityEmployee;
  public mensajeEmployeeEmpy = "";
  url;

  constructor(private api: ApiService, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'api/employee';
  }

  ngOnInit() {
  }

  searchEmployee() {
    if (this.identityEmployee == null) {
      this.identityEmployee = "";
    }
    this.api
      .getListOfGroup(this.url + "?identity=" + this.identityEmployee)
      .subscribe(
        data => {
          if (data.length > 0) {
            this.employees = data;
            this.mensajeEmployeeEmpy = "";
          } else {
            this.employees = null;
            this.mensajeEmployeeEmpy = "The identity from employee not exist";
          }
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
  AnnualSalary: number,
  Contract: string,
}
