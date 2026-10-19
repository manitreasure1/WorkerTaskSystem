Imports System.ComponentModel.DataAnnotations

Public Enum WorkingDaysPattern
    MondayToFriday
    WeekendsOnly
    AllDays
End Enum

Public Class Worker
    <Key>
    Public Property Id As Guid = Guid.NewGuid()

    <Required>
    <StringLength(50)>
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


    Public Property WorkingDayPattern As WorkingDaysPattern = WorkingDaysPattern.MondayToFriday

    Public Property CreatedAt As DateTimeOffset = DateTimeOffset.UtcNow
    Public Property UpdateAt As DateTimeOffset = DateTimeOffset.UtcNow

    Public Overridable Property Users As Users

    Public Overridable Property AvailabilityRecords As ICollection(Of Availability) = New List(Of Availability)()

    Public Overridable Property ShiftAssignments As ICollection(Of WorkerShiftAssignment) = New List(Of WorkerShiftAssignment)()

    Public Overridable Property RoleApprovals As ICollection(Of WorkerRoleApprovals) = New List(Of WorkerRoleApprovals)()
    Public Overridable Property TaskAssignments As ICollection(Of TaskAssignment) = New List(Of TaskAssignment)()


    Public Overridable Property NotificationLogs As ICollection(Of Notification) = New List(Of Notification)()




End Class
