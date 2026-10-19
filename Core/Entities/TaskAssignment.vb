Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Enum TaskAssignmentStatus
    Assigned
    Completed
    Cancelled
End Enum

Public Class TaskAssignment
    <Key>
    Public Property Id As Guid = Guid.NewGuid()

    <Required>
    Public Property TaskId As Guid

    <Required>
    Public Property WorkerId As Guid

    <Required>
    Public Property AssignmentStatus As TaskAssignmentStatus = TaskAssignmentStatus.Assigned

    Public Property AssignedAt As DateTimeOffset = DateTimeOffset.UtcNow


    <ForeignKey("TaskId")>
    Public Overridable Property Task As Task

    <ForeignKey("WorkerId")>
    Public Overridable Property Worker As Worker
End Class
