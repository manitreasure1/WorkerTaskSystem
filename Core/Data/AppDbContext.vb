Imports Microsoft.EntityFrameworkCore

Public Class AppDbContext
    Inherits DbContext
    Public Sub New(options As DbContextOptions(Of AppDbContext))
        MyBase.New(options)
    End Sub

    Public Property Users As DbSet(Of Users)
    Public Property Workers As DbSet(Of Worker)
    Public Property WorkSessions As DbSet(Of WorkSession)
    Public Property TaskRoles As DbSet(Of TaskRole)
    Public Property WorkerRoleApprovals As DbSet(Of WorkerRoleApprovals)
    Public Property WorkerShiftAssignments As DbSet(Of WorkerShiftAssignment)
    Public Property Availability As DbSet(Of Availability)
    Public Property Tasks As DbSet(Of Task)
    Public Property TaskAssignments As DbSet(Of TaskAssignment)
    Public Property Audit As DbSet(Of Audit)
    Public Property Notification As DbSet(Of Notification)



    Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.Entity(Of Worker)(Sub(entity)
                                           entity.HasIndex(Function(w) w.Email).IsUnique()
                                           entity.Property(Function(w) w.WorkingDayPattern) _
                                           .HasColumnName("WorkingDayPattern") _
                                           .HasConversion(Of String)() _
                                           .HasMaxLength(15)
                                           entity.ToTable(Sub(t) t.HasCheckConstraint("CK_Worker_WorkingDayPattern", """WorkingDayPattern"" IN ('MondayToFriday', 'WeekendsOnly', 'AllDays')"))

                                       End Sub)

        modelBuilder.Entity(Of Users)(Sub(entity)
                                          entity.HasIndex(Function(u) u.UserName).IsUnique()

                                          entity.Property(Function(u) u.Role) _
                                          .HasColumnName("Role") _
                                          .HasConversion(Of String)() _
                                          .HasMaxLength(15)
                                          entity.ToTable(Sub(t) t.HasCheckConstraint("CK_UserAccount_Role", """Role"" IN ('Manager', 'Worker')"))

                                          entity.HasOne(Function(u) u.Worker) _
                                              .WithOne(Function(w) w.Users) _
                                              .HasForeignKey(Of Users)(Function(u) u.WorkerId) _
                                              .OnDelete(DeleteBehavior.Cascade)
                                      End Sub)

        modelBuilder.Entity(Of WorkerRoleApprovals)(Sub(entity)

                                                        entity.HasIndex(Function(wra) New With {wra.WorkerId, wra.RoleId}).IsUnique()


                                                        entity.HasOne(Function(wra) wra.Worker) _
                                                             .WithMany(Function(w) w.RoleApprovals) _
                                                             .HasForeignKey(Function(wra) wra.WorkerId) _
                                                             .OnDelete(DeleteBehavior.Cascade)

                                                        entity.HasOne(Function(wra) wra.TaskRole) _
                                                             .WithMany(Function(r) r.WorkerApprovals) _
                                                             .HasForeignKey(Function(wra) wra.RoleId) _
                                                             .OnDelete(DeleteBehavior.Cascade)
                                                    End Sub)

        modelBuilder.Entity(Of WorkerShiftAssignment)(Sub(entity)

                                                          entity.HasIndex(Function(wsa) New With {wsa.WorkerId, wsa.Year, wsa.Month}).IsUnique()

                                                          entity.Property(Function(wsa) wsa.CustomStartTime).HasColumnType("time")
                                                          entity.Property(Function(wsa) wsa.CustomEndTime).HasColumnType("time")


                                                          entity.HasOne(Function(wsa) wsa.Worker) _
                                                              .WithMany(Function(w) w.ShiftAssignments) _
                                                              .HasForeignKey(Function(wsa) wsa.WorkerId) _
                                                              .OnDelete(DeleteBehavior.Cascade)
                                                          entity.Property(Function(wsa) wsa.Month) _
                                                            .HasColumnName("Month")

                                                          entity.HasOne(Function(wsa) wsa.WorkSession) _
                                                              .WithMany(Function(s) s.WorkerAssignments) _
                                                              .HasForeignKey(Function(wsa) wsa.SessionId) _
                                                              .OnDelete(DeleteBehavior.Restrict)


                                                          entity.ToTable(Sub(t) t.HasCheckConstraint("CK_ShiftAssignment_MonthRange", """Month"" BETWEEN 1 AND 12"))
                                                      End Sub)


        modelBuilder.Entity(Of Availability)(Sub(entity)
                                                 entity.Property(Function(ar) ar.EndDateTime) _
                                                    .HasColumnName("EndDateTime")


                                                 entity.Property(Function(ar) ar.StartDateTime) _
                                                 .HasColumnName("StartDateTime")

                                                 entity.HasOne(Function(ar) ar.Worker) _
                                                             .WithMany(Function(w) w.AvailabilityRecords) _
                                                             .HasForeignKey(Function(ar) ar.WorkerId) _
                                                             .OnDelete(DeleteBehavior.Cascade)


                                                 entity.ToTable(Sub(t) t.HasCheckConstraint("CK_AvailabilityRecord_Dates", """EndDateTime"" > ""StartDateTime"""))
                                             End Sub)


        modelBuilder.Entity(Of Task)(Sub(entity)

                                         entity.Property(Function(t) t.Status) _
                                         .HasColumnName("Status") _
                                         .HasConversion(Of String)() _
                                               .HasMaxLength(30)

                                         entity.Property(Function(t) t.EndTime) _
                                         .HasColumnName("EndTime")

                                         entity.Property(Function(t) t.StartTime) _
                                         .HasColumnName("StartTime")

                                         entity.Property(Function(t) t.WorkersRequired) _
                                         .HasColumnName("WorkersRequired")



                                         entity.ToTable(Sub(t)
                                                            t.HasCheckConstraint("CK_Task_WorkersRequired", """WorkersRequired"" >= 1")
                                                            t.HasCheckConstraint("CK_Task_TimeRange", """EndTime"" > ""StartTime""")
                                                            t.HasCheckConstraint("CK_Task_StatusPattern", """Status"" IN ('Scheduled', 'InProgress', 'Completed', 'Cancelled')")
                                                        End Sub)


                                         entity.HasOne(Function(t) t.RequiredRole) _
                                               .WithMany() _
                                               .HasForeignKey(Function(t) t.RequiredRoleId) _
                                               .OnDelete(DeleteBehavior.Restrict)

                                         entity.HasOne(Function(t) t.CreatedByUser) _
                                               .WithMany() _
                                               .HasForeignKey(Function(t) t.CreatedByUserId) _
                                               .OnDelete(DeleteBehavior.SetNull)

                                         entity.HasOne(Function(t) t.CancelledByUser) _
                                               .WithMany() _
                                               .HasForeignKey(Function(t) t.CancelledByUserId) _
                                               .OnDelete(DeleteBehavior.SetNull)
                                     End Sub)


        modelBuilder.Entity(Of TaskAssignment)(Sub(entity)

                                                   entity.HasIndex(Function(ta) New With {ta.TaskId, ta.WorkerId}).IsUnique()


                                                   entity.Property(Function(ta) ta.AssignmentStatus) _
                                                       .HasColumnName("AssignmentStatus") _
                                                      .HasConversion(Of String)() _
                                                      .HasMaxLength(30)


                                                   entity.ToTable(Sub(t) t.HasCheckConstraint("CK_TaskAssignment_Status", """AssignmentStatus"" IN ('Assigned', 'Completed', 'Cancelled')"))

                                                   entity.HasOne(Function(ta) ta.Task) _
              .WithMany(Function(t) t.Assignments) _
              .HasForeignKey(Function(ta) ta.TaskId) _
              .OnDelete(DeleteBehavior.Cascade)

                                                   entity.HasOne(Function(ta) ta.Worker) _
              .WithMany(Function(w) w.TaskAssignments) _
              .HasForeignKey(Function(ta) ta.WorkerId) _
              .OnDelete(DeleteBehavior.Cascade)
                                               End Sub)

        modelBuilder.Entity(Of Audit)(Sub(entity)
                                          entity.HasOne(Function(ar) ar.Users) _
                                                      .WithMany() _
                                                      .HasForeignKey(Function(ar) ar.UserId) _
                                                      .OnDelete(DeleteBehavior.SetNull)
                                      End Sub)


        modelBuilder.Entity(Of Notification)(Sub(entity)

                                                 entity.Property(Function(nl) nl.Status) _
                                                        .HasColumnName("Status") _
                                                          .HasConversion(Of String)() _
                                                          .HasMaxLength(20)


                                                 entity.ToTable(Sub(t) t.HasCheckConstraint("CK_NotificationLog_Status", """Status"" IN ('Pending', 'Sent', 'Failed')"))


                                                 entity.HasOne(Function(nl) nl.Worker) _
                                                          .WithMany(Function(w) w.NotificationLogs) _
                                                          .HasForeignKey(Function(nl) nl.WorkerId) _
                                                          .OnDelete(DeleteBehavior.Cascade)
                                             End Sub)



    End Sub

End Class
