Imports System.Globalization
Imports System.IO

Public Class oLog

    Enum AppendMode
        None = False
        Append = True
    End Enum

    Private Shared _path As String = String.Empty
    Private Shared _appendMode As Boolean = AppendMode.Append

    Property Path As String
        Set(value As String)
            _path = value
        End Set
        Get
            Return _path
        End Get
    End Property

    Property Message As String

    Sub New()

    End Sub

    Sub New(path As String)
        _path = path
    End Sub

    Sub New(path As String, append As AppendMode)
        _path = path
        _appendMode = append
    End Sub

    Sub Save()
        _write(_path, Message, _appendMode)
    End Sub

    Sub Info(message As String)
        message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) & Space(1) & "[Info]:" & Space(1) & message
        _write(_path, message, _appendMode)
    End Sub

    Sub Warning(message As String)
        message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) & Space(1) & "[Warning]:" & Space(1) & message
        _write(_path, message, _appendMode)
    End Sub

    Sub [Error](message As String)
        message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.GetCultureInfo("en-US")) & Space(1) & "[Error]:" & Space(1) & message
        _write(_path, message, _appendMode)
    End Sub

    Private Sub _write(path As String, msg As String, append As AppendMode)
        Dim _sw As StreamWriter = Nothing
        Try
            _sw = New StreamWriter(path, append)
            _sw.WriteLine(msg)
        Catch ex As DirectoryNotFoundException

        Catch ex As UnauthorizedAccessException

        Catch ex As IOException

        Finally
            _sw.Close()
        End Try
    End Sub

End Class
