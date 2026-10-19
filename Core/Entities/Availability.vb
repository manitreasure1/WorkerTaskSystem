Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Availability

    <Key>
    Public Property Id As Guid = Guid.NewGuid()

    <Required>
    Public Property WorkerId As Guid

    <Required>
    Public Property StartDateTime As DateTimeOffset

    <Required>
    Public Property EndDateTime As DateTimeOffset

    Public Property Reason As String

    Public Property CreatedAt As DateTimeOffset = DateTimeOffset.UtcNow

    <ForeignKey("WorkerId")>
    Public Overridable Property Worker As Worker

End Class
