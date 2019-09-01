
Imports System.Data.SqlClient
Imports System.Data

Public Class conexiondb
    Private conexion As SqlConnection
    Private cadenaconexion As String = "Data Source=PCGTUMG017\SQLEXPRESS; Initial Catalog=comercial; Integrated Security=True; encrypted=true; trustServerCertificate=true"


    Public Sub New()
        Me.conexion = New SqlConnection(Me.cadenaconexion)
        Me.conexion.Open()
    End Sub

    Public Function ejconsulta(ByVal query As String)
        Dim tabla As New DataTable
        Dim adaptador As New SqlDataAdapter
        Dim cmd As New SqlCommand

        cmd.Connection = Me.conexion
        cmd.CommandType = CommandType.Text
        cmd.CommandText = query
        adaptador.SelectCommand = cmd
        adaptador.Fill(tabla)

        If (Me.conexion.State = ConnectionState.Open) Then
            Me.conexion.Close()
        End If

        Return tabla

    End Function



End Class