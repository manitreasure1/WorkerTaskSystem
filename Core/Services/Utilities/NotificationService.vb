Public Class NotificationService

    Public Async Function DispatchAlert(recipientId As Guid, message As String, category As String) As Task(Of Task)
        Throw New NotImplementedException()
    End Function


    Public Async Function MarkAsRead(notificationId As Guid) As Task(Of Boolean)
        Throw New NotImplementedException()

    End Function

End Class
