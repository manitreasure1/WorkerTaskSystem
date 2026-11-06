Public Class WorkerManagementService
    Private ReadOnly _dbContext As AppDbContext

    Sub New(context As AppDbContext)
        _dbContext = context
    End Sub

    Public Async Function RegisterWorker(worker As AddWorkerRequest) As Task(Of Guid)
        Throw New NotImplementedException()
    End Function

    Public Async Function SetWorkerStatus(workerId As Guid, isAtive As Boolean) As Task(Of Boolean)
        Throw New NotImplementedException()
    End Function

    Public Async Function GetWorkerDetails(workerId As Guid) As Task(Of Worker)
        Throw New NotImplementedException()
    End Function


End Class
