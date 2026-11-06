Public Class ShiftAllocationService

    Private ReadOnly _dbContext As AppDbContext

    Sub New(context As AppDbContext)
        _dbContext = context
    End Sub

    Public Async Function ValidateAvailability(workerId As Guid, shiftDate As DateTime) As Task(Of Boolean)
        Throw New NotImplementedException()
    End Function

    Public Async Function GenerateMonthlyRotation(year As Integer, month As Integer) As Task(Of Boolean)
        Throw New NotImplementedException()
    End Function

End Class
