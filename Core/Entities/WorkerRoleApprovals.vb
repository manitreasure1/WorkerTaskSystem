Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class WorkerRoleApprovals

    <Key>
    Public Property Id As Guid = Guid.NewGuid()

    <Required>
    Public Property WorkerId As Guid

    <Required>
    Public Property RoleId As Guid

    Public Property ApprovedAt As DateTimeOffset = DateTimeOffset.UtcNow


    <ForeignKey("WorkerId")>
    Public Overridable Property Worker As Worker

    <ForeignKey("RoleId")>
    Public Overridable Property TaskRole As TaskRole

End Class
