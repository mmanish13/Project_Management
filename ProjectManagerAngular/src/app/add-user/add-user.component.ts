import { Component, OnInit, Inject } from '@angular/core';
import { User } from '../user';
import { Router } from '@angular/router';
import { TaskService } from '../task.service';


@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit {

  public _taskService!: TaskService;
  public addUser: User = new User();
  public availableUsers!: User[];
  public userSearch: UserSearch = new UserSearch();
  constructor(private taskService: TaskService, private router: Router) {
    this._taskService = taskService;
    this.addUserHeader = 'Add User';
  };
  public addUserHeader: string = 'Add User';

  ngOnInit() {
    this.addUserHeader = 'Add User';
    this.searchUsers();

  }

  headers = ['First Name', 'Last Name','Employee Id', '#'];

  getUserDetails(userId: any) {
    this._taskService.getUser(parseInt(userId)).subscribe(
      result => {
        this.addUser = result;
      }
    );
  }

  searchUsers() {
    this._taskService.getAllUsers().subscribe(
      lstResults => {
        let result: User[] = lstResults;
        if (this.userSearch.FirstName !== "") {
          result = result.filter(t => t.FirstName.includes(this.userSearch.FirstName));
        }
        if (this.userSearch.LastName !== "") {
          result = result.filter(t => t.LastName.includes(this.userSearch.LastName));
        }
        if (this.userSearch.EmployeeId !== "") {
          result = result.filter(t => t.EmployeeId.includes(this.userSearch.EmployeeId));
        }
        this.availableUsers = result;
      }
    );
    console.log(this.availableUsers);
  }

  SortByFirstName() {
    this._taskService.getAllUsers().subscribe(
      lstResults => {
        let result: User[] = lstResults;
        result = result.sort((a, b) => a.FirstName.toUpperCase() > b.FirstName.toUpperCase() ? 1 : -1);
        this.availableUsers = result;
      }
    );
  }

  SortByLastName() {
    this._taskService.getAllUsers().subscribe(
      lstResults => {
        let result: User[] = lstResults;
        result = result.sort((a, b) => a.LastName.toUpperCase() > b.LastName.toUpperCase() ? 1 : -1);
        this.availableUsers = result;
      }
    );
  }

  SortByEmployeeId() {
    this._taskService.getAllUsers().subscribe(
      lstResults => {
        let result: User[] = lstResults;
        result = result.sort((a, b) => a.EmployeeId.toUpperCase() > b.EmployeeId.toUpperCase() ? 1 : -1);
        this.availableUsers = result;
      }
    );
  }

  deleteUser(user: User) {
    this._taskService.deleteUser(user.UserId).subscribe(
      result => {
        alert('User deleted successfully.');
        this.searchUsers();
      }
    );
  }
  editUser(user: User) {
    this.addUser = new User();
    this.addUserHeader = 'Update User';
    document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
    this.getUserDetails(user.UserId);
  }
  updateUser() {
    if (this.addUser.UserId === 0) {
      this._taskService.addUser(this.addUser).subscribe(
        result => {
          alert('User saved successfully.');
          this.addUser = new User();
          this.searchUsers();
        }
      );
    }
    else {
      this._taskService.updateUser(this.addUser).subscribe(
        result => {
          alert('User saved successfully.');
          this.addUser = new User();
          this.searchUsers();
        }
      );
    }

  }

  newUser() {
    this.addUser = new User();
  }
  cancelUser() {
    this.addUser = new User();
  }


  sortUser(sortBy: string) {

  }

  reset() {
    this.addUserHeader = 'Add User';
    this.addUser = new User();
  }
}

export class UserSearch {
  FirstName: string = "";
  LastName: string = "";
  EmployeeId: string = "";
}