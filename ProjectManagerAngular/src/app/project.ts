export class Project {
    ProjectId: number = 0;
    Name: string = "";
    StartDate: string = new Date().toISOString().split('T')[0];
    EndDate: string = new Date().toISOString().split('T')[0];
    Priority: number = 0;
    ManagerId!: number;
  }