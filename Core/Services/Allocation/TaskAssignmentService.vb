Public Class TaskAssignmentService

    Private ReadOnly _dbContext As AppDbContext

    Sub New(context As AppDbContext)
        _dbContext = context
    End Sub


    Public Async Function AssignTaskToWorker(taskId As Guid, workerId As Guid) As Task(Of Boolean)

        Throw New NotImplementedException()
    End Function

    Public Async Function GetWorkerActiveLoad(workerId As Guid) As Task(Of Integer)
        Throw New NotImplementedException()
    End Function

    Public Async Function UpdateTaskStatus(taskId As Guid, newStatus As TaskStatus) As Task(Of Boolean)
        Throw New NotImplementedException()
    End Function



End Class
