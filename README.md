# WorkerTaskSystem
Worker Task System Desktop Application


## Prerequisites
- Visual Studio 2022 (with the .NET Desktop Development workload checked).
- .NET 10.0 SDK.
- PostgreSQL (with pgAdmin database manager running locally).

### Clone the Repository
```bash
git clone https://github.com/manitreasure1/WorkerTaskSystem.git
cd WorkerTaskSystem
```

### PostgreSQL Setup(Default)
[Connection String ](./UI/LoginForm.vb)

- Host: localhost
- Port 5432
- Username: postgres
• Password: @@ (change this to your local Postgres Password)

### Install Dependencies
open your terminal(ctrl + `) and run
```bash
dotnet restore
```


## DataBase and Tables
Default Database Name: worker_task_db with 11 tables.

- [Worker](./Core/Entities/Worker.vb): The main registry for employees details.
- [Users](./Core/Entities/User.vb): Holds Login Credentials
- [WorkSession](./Core/Entities/WorkSession.vb): Defines shift configurations(Morning, Afternoon, Night)
- [TaskRole](./Core/Entities/TaskRole.vb): Defines technical positions or skills required to do a job 
- [WorkerRoleApprovals](./Core/Entities/WorkerRoleApprovals.vb): it links Workers to TaskRoles and tracks who is approved to do what job, and prevents a worker from being assigned a task they aren't qualified for.
- [WorkerShiftAssignment](./Core/Entities/WorkerShiftAssignment.vb): It binds a [Worker](./Core/Entities/Worker.vb) to a [WorkSession](./Core/Entities/WorkSession.vb) for a specific Year and Month.
- [Availability](./Core/Entities/Availability.vb): Tracks worker leaves, holidays, time-off, or sick days.
- [Task](./Core/Entities/Task.vb): Specific job orders created by managers.
- [TaskAssignment](./Core/Entities/TaskAssignment.vb): It links Workers directly to scheduled Tasks.
- [Audit](./Core/Entities/Audit.vb): Whenever a manager alters a schedule or cancels a task, it logs the action.
- [Notification](./Core/Entities/Notification.vb): Tracks automated messages sent out to workers and monitors if they are Pending, Sent, or Failed.

