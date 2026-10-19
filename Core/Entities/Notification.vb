
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Enum NotificationStatus
    Pending
    Sent
    Failed
End Enum
Public Class Notification

    <Key>
    Public Property Id As Guid = Guid.NewGuid()

    <Required>
    Public Property WorkerId As Guid

    <Required>
    <StringLength(50)>
    Public Property NotificationType As String = "DailyTaskSummary"

    <Required>
    Public Property Payload As String

    <Required>
    Public Property Status As NotificationStatus = NotificationStatus.Pending

    Public Property ErrorMessage As String

    Public Property SentAt As DateTimeOffset? = Nothing

    Public Property CreatedAt As DateTimeOffset = DateTimeOffset.UtcNow

    ' Navigation Property
    <ForeignKey("WorkerId")>
    Public Overridable Property Worker As Worker

End Class
