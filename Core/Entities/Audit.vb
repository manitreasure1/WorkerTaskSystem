Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Public Enum ActionType
    TASK_CANCELLED
    SCHEDULE_AMENDED
    TASK_ASSIGNED
    TASK_COMPLETED
    WORKER_ADDED
    WORKER_REMOVED
    ROLE_APPROVED
    ROLE_REVOKED
End Enum
Public Class Audit

    <Key>
    Public Property Id As Guid = Guid.NewGuid()
    Public Property UserId As Guid?

    <Required>
    <StringLength(50)>
    Public Property ActionType As ActionType

    <Required>
    <StringLength(50)>
    Public Property EntityName As String

    <Required>
    Public Property EntityId As Guid

    <Required>
    Public Property Details As String

    Public Property PerformedAt As DateTimeOffset = DateTimeOffset.UtcNow

    <ForeignKey("UserId")>
    Public Overridable Property Users As Users

End Class
