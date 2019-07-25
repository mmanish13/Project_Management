import { Component, OnInit } from '@angular/core';
import { Options } from 'ng5-slider';
import { Project } from '../project';
import { TaskService } from '../task.service';
import { Router } from '@angular/router';
import { User } from '../user';


@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.scss']
})
export class AddProjectComponent implements OnInit {
  public addProjectHeader: string = 'Add Project';
  public chkStartEndDate: boolean = true;
  public project: Project = new Project();
  options: Options = {
    floor: 0,
    ceil: 30
  };
  public _taskService!: TaskService;
  public addProject: Project = new Project();
  public start: string = new Date().toISOString().split('T')[0];
  public end: string = new Date().toISOString().split('T')[0];
  public availableUsers!: User[];
  public availableProjects!: Project[];
  public projectSearch: ProjectSearch = new ProjectSearch();
  constructor(private taskService: TaskService, private router: Router) {
    this._taskService = taskService;
  };


  ngOnInit() {
    this.addProjectHeader = 'Add Project'
    this.getAllUsers();
    this.searchProjects();
  }

  getProjectDetails(projectId: any) {
    this._taskService.getProject(parseInt(projectId)).subscribe(
      result => {
        console.log(result);
        this.addProject = result;
        this.start = result.StartDate;
        this.end = result.EndDate;
      }
    );
  }

  getAllUsers() {
    this._taskService.getAllUsers().subscribe(
      lstResults => {
        this.availableUsers = lstResults;
      }
    );
  }

  saveTask() {
    this._taskService.addProject(this.addProject).subscribe(
      result => {
        alert('Project saved successfully.');
        this.searchProjects();
      }
    );
  }
  priorityChanged(value: any) {
    this.addProject.Priority = value;
  }

  searchProjects() {
    this._taskService.getAllProjects().subscribe(
      lstResults => {
        let result: Project[] = lstResults;
        if (this.projectSearch.Name !== "") {
          result = result.filter(t => t.Name.includes(this.projectSearch.Name));
        }
        result = result.filter(t => t.Priority >= this.projectSearch.PriorityFrom && t.Priority <= this.projectSearch.PriorityTo);
        this.availableProjects = result;
      }
    );
    console.log(this.availableProjects);
  }

  SortByName() {
    this._taskService.getAllProjects().subscribe(
      lstResults => {
        let result: Project[] = lstResults;
        result = result.sort((a, b) => a.Name.toUpperCase() > b.Name.toUpperCase() ? 1 : -1);
        this.availableProjects = result;
      }
    );
  }

  SortByPriority() {
    this._taskService.getAllProjects().subscribe(
      lstResults => {
        let result: Project[] = lstResults;
        result = result.sort((a, b) => a.Priority > b.Priority ? 1 : -1);
        this.availableProjects = result;
      }
    );
  }

  SortByStartDate() {
    this._taskService.getAllProjects().subscribe(
      lstResults => {
        let result: Project[] = lstResults;
        result = result.sort((a, b) => a.StartDate > b.StartDate ? 1 : -1);
        this.availableProjects = result;
      }
    );
  }

  SortByEndDate() {
    this._taskService.getAllProjects().subscribe(
      lstResults => {
        let result: Project[] = lstResults;
        result = result.sort((a, b) => a.EndDate > b.EndDate ? 1 : -1);
        this.availableProjects = result;
      }
    );
  }

  deleteProject(project: Project) {
    this._taskService.deleteProject(project.ProjectId).subscribe(
      result => {
        alert('Project deleted successfully.');
        this.searchProjects();
      }
    );
  }
  editProject(project: Project) {
    this.addProject = new Project();
    this.getProjectDetails(project.ProjectId);
  }
  updateProject() {
    if (this.addProject.ProjectId === 0) {
      this._taskService.addProject(this.addProject).subscribe(
        result => {
          alert('Project saved successfully.');
          this.addProject = new Project();
          this.searchProjects();
        }
      );
    }
    else {
      this._taskService.updateProject(this.addProject).subscribe(
        result => {
          alert('Project saved successfully.');
          this.addProject = new Project();
          this.searchProjects();
        }
      );
    }

  }

  newProject() {
    this.addProject = new Project();
  }
  cancelProject() {
    this.addProject = new Project();
  }

  reset() {
    this.addProjectHeader = 'Add Project'
  }

}

export class ProjectSearch {
  Name: string = "";
  PriorityFrom: number = 0;
  PriorityTo: number = 30;
  StartDate: string = new Date().toISOString().split('T')[0];
  EndDate: string = new Date().toISOString().split('T')[0];
}
