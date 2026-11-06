Public Class RoleApprovalService

    Private ReadOnly _dbContext As AppDbContext

    Sub New(context As AppDbContext)
        _dbContext = context
    End Sub
    Public Async Function SubmitRoleRequest(wokerId As Guid, roleId As Guid) As Task(Of Guid)
        Throw New NotImplementedException()

    End Function

    Public Async Function ProcessApproval(approvalId As Guid, isApproved As Boolean) As Task(Of Boolean)
        Throw New NotImplementedException()

    End Function

    Public Async Function GetPendingApprovals() As Task(Of List(Of WorkerRoleApprovals))
        Throw New NotImplementedException()

    End Function



End Class
