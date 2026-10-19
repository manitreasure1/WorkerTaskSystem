Imports System.ComponentModel.DataAnnotations

Public Class TaskRole

    <Key>
    Public Property RoleId As Guid = Guid.NewGuid()

    <Required>
    <StringLength(100)>
    Public Property RoleName As String

    Public Property Description As String

    Public Property IsActive As Boolean = True

    Public Overridable Property WorkerApprovals As ICollection(Of WorkerRoleApprovals) = New List(Of WorkerRoleApprovals)()

End Class

