import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Task } from './task';
import { Observable } from 'rxjs';
import { ParentTask } from './parent-task';
import { environment } from '../environments/environment';
import { User } from './user';
import { Project } from './project';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  BaseUrl = environment.baseUrl;
  
  constructor(private http: HttpClient) { }

  public getAllTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.BaseUrl + '/GetAllTasks');
  }
  public getTask(taskId: number): Observable<Task> {
    return this.http.get<Task>(this.BaseUrl + '/getTask/' + taskId);
  }
  public getAllParentTasks(): Observable<ParentTask[]> {
    return this.http.get<ParentTask[]>(this.BaseUrl + '/getAllParentTasks');
  }
  public addTask(task: Task): Observable<any> {
    return this.http.post<any>(this.BaseUrl + '/addTask', task);
  }
  public updateTask(task: Task): Observable<any> {
    return this.http.post<any>(this.BaseUrl + '/updateTask', task);
  }
  public endTask(taskId: number): Observable<any> {
    return this.http.get<any>(this.BaseUrl + '/deleteTask/ ' + taskId);
  }
  public getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.BaseUrl + '/GetAllUsers');
  }
  public getUser(userId: number): Observable<User> {
    return this.http.get<User>(this.BaseUrl + '/GetUser/' + userId);
  }
  public addUser(user: User): Observable<any> {
    return this.http.post<any>(this.BaseUrl + '/AddUser', user);
  }
  public updateUser(user: User): Observable<any> {
    return this.http.post<any>(this.BaseUrl + '/UpdateUser', user);
  }
  public deleteUser(projectId: number): Observable<any> {
    return this.http.get<any>(this.BaseUrl + '/DeleteUser/ ' + projectId);
  }
  public getAllProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.BaseUrl + '/GetAllProjects');
  }
  public getProject(projectId: number): Observable<Project> {
    return this.http.get<Project>(this.BaseUrl + '/GetProject/' + projectId);
  }
  public addProject(project: Project): Observable<any> {
    return this.http.post<any>(this.BaseUrl + '/AddProject', project);
  }
  public updateProject(project: Project): Observable<any> {
    return this.http.post<any>(this.BaseUrl + '/UpdateProject', project);
  }
  public deleteProject(projectId: number): Observable<any> {
    return this.http.get<any>(this.BaseUrl + '/DeleteProject/ ' + projectId);
  }
  
}
