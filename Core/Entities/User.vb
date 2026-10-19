Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Public Enum UserRole
    Worker
    Manager
End Enum
Public Class Users
    <Key>
    Public Property Id As Guid = New Guid()

    Public Property WorkerId As Guid?

    <Required>
    <StringLength(50)>
    Public Property UserName As String

    <Required>
    Public Property PasswordHash As String

    Public Property Role As UserRole = UserRole.Worker

    Public Property IsActive As Boolean = True

    Public Property LastLogin As DateTimeOffset? = Nothing

    <ForeignKey("WorkerId")>
    Public Overridable Property Worker As Worker

End Class
