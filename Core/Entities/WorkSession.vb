Imports System.ComponentModel.DataAnnotations

Public Enum ShiftType
    Morning
    Afternoon
    Night
End Enum
Public Class WorkSession

    <Key>
    Public Property SessionId As Guid = Guid.NewGuid()

    <Required>
    <StringLength(50)>
    Public Property SessionName As ShiftType

    <Required>
    Public Property StartTime As TimeSpan


    <Required>
    Public Property DurationMinutes As Integer

    Public Property IsActive As Boolean = True

    Public Property CreatedAt As DateTimeOffset = DateTimeOffset.UtcNow

    Public Overridable Property WorkerAssignments As ICollection(Of WorkerShiftAssignment) = New List(Of WorkerShiftAssignment)()


End Class
