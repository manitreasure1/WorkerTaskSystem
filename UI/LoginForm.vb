Imports Microsoft.EntityFrameworkCore

Public Class LoginForm
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim connectionString As String = "Host=localhost;Database=worker_task_db;Username=postgres;Password=mani@@"


            Dim optionBuilder As New DbContextOptionsBuilder(Of AppDbContext)()
            optionBuilder.UseNpgsql(connectionString)

            Using db As New AppDbContext(optionBuilder.Options)
                db.Database.EnsureDeleted()
                db.Database.EnsureCreated()
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MessageBox.Show("Database Initialization Error: " & ex.Message, "Database Connection Failed", MessageBoxButtons.OK)
            Application.Exit()
        End Try
    End Sub
End Class