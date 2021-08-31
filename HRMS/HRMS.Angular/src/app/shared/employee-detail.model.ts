export class EmployeeDetails {
  employeeId: number = 0;
  name: string = '';
  surname: string = '';
  sex: string = '';
  age: string = '';
  position: string = '';
  phone: string = '';
  departmentId: number = 0;
  permissions: Permissions = 0;
}

enum Permissions {
  None = 0,
  Read = 0x001,
  Write = 0x010,
  Delete = 0x100,
}
