Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class WorkerShiftAssignment

    <Key>
    Public Property Id As Guid = Guid.NewGuid()

    <Required>
    Public Property WorkerId As Guid

    <Required>
    Public Property SessionId As Guid

    <Required>
    Public Property Year As Integer

    <Required>
    Public Property Month As Integer

    Public Property CustomStartTime As TimeSpan?

    Public Property CustomEndTime As TimeSpan?

    Public Property IsPublished As Boolean = False

    Public Property CreatedAt As DateTimeOffset = DateTimeOffset.UtcNow

    Public Property UpdatedAt As DateTimeOffset = DateTimeOffset.UtcNow

    <ForeignKey("WorkerId")>
    Public Overridable Property Worker As Worker

    <ForeignKey("SessionId")>
    Public Overridable Property WorkSession As WorkSession

End Class
