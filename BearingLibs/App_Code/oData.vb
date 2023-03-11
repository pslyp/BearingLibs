Imports System.Data
Imports System.Data.OleDb

Public Class oData

    Private Shared _connStr As String = String.Empty
    Private _data As DataTable = Nothing

    WriteOnly Property DefaultConnectionString As String
        Set(value As String)
            _connStr = value
        End Set
    End Property

    ReadOnly Property DataTable As DataTable
        Get
            Return _data
        End Get
    End Property

    Sub New()

    End Sub

    Sub New(connectionString As String)
        _connStr = connectionString
    End Sub

    Sub Execute(command As String)
        _execute(command, _connStr)
    End Sub

    Private Sub _execute(cmd As String, connStr As String)
        '_data = New DataTable
        Try
            Using _conn As New OleDbConnection(connStr)
                _conn.Open()
                Using _da As New OleDbDataAdapter(cmd, _conn)
                    _da.Fill(_data)
                End Using
                _conn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, Nothing, "Error Exception: Database Execute")
        End Try
    End Sub

End Class
