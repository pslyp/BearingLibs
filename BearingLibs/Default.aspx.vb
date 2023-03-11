
Imports System.IO
Imports System.Net.Mail

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim logFile As String = "~/Logs/logs.log"
    Dim log As oLog

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        log = New oLog(Server.MapPath(logFile))
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        log.Info("Test Log.")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim data As New oData("Provider=SQLNCLI11;Data Source=localhost;Integrated Security=SSPI;")
        data.Execute("Select * from tppr1d.pk010p ")
        Dim dt = data.DataTable
    End Sub

End Class
