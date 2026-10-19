Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Public Enum TaskStatus
    Scheduled
    InProgress
    Completed
    Cancelled
End Enum
Public Class Task
    <Key>
    Public Property Id As Guid = Guid.NewGuid()

    <Required>
    <StringLength(150)>
    Public Property Title As String

    Public Property Description As String

    <Required>
    Public Property RequiredRoleId As Guid

    <Required>
    Public Property TaskDate As DateOnly

    <Required>
    Public Property StartTime As TimeOnly

    <Required>
    Public Property EndTime As TimeOnly

    <Required>
    Public Property WorkersRequired As Integer = 1

    <StringLength(150)>
    Public Property Location As String

    <Required>
    Public Property Status As TaskStatus = TaskStatus.Scheduled


    Public Property CreatedByUserId As Guid?
    Public Property CancelledByUserId As Guid?
    Public Property CancelledAt As DateTimeOffset?
    Public Property CancellationReason As String

    Public Property CreatedAt As DateTimeOffset = DateTimeOffset.UtcNow
    Public Property UpdatedAt As DateTimeOffset = DateTimeOffset.UtcNow

    ' Navigation Properties
    <ForeignKey("RequiredRoleId")>
    Public Overridable Property RequiredRole As TaskRole

    <ForeignKey("CreatedByUserId")>
    Public Overridable Property CreatedByUser As Users

    <ForeignKey("CancelledByUserId")>
    Public Overridable Property CancelledByUser As Users

    Public Overridable Property Assignments As ICollection(Of TaskAssignment) = New List(Of TaskAssignment)()


End Class

