Imports System.ComponentModel.DataAnnotations

Public Class AddWorkerRequest

    Public Property FirstName As String

    <Required>
    <StringLength(50)>
    Public Property LastName As String

    <Required>
    <EmailAddress(ErrorMessage:="Invalid Email Address format.")>
    <RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage:="Email does not match expression rules.")>
    <StringLength(50)>
    Public Property Email As String

    <Required>
    <StringLength(30)>
    Public Property PhoneNumber As String

End Class
