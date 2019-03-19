
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient

Partial Public Class SQL_DB
    Public Shared dt2 As New DataTable
    Public Shared dr2 As DataRow
    Public dread As SqlClient.SqlDataReader
    Public Shared ReadOnly Property ConnectionString() As String
        Get
            Return System.Configuration.ConfigurationManager.ConnectionStrings("con").ConnectionString
        End Get
    End Property
    Public Shared Function divcut(ByVal tr1 As String) As String
        Dim ic1 As Integer
        Dim str2, tr5 As String
        If tr1 <> "" Or tr1 <> Nothing Then
            ic1 = InStr(1, tr1, "-")
            str2 = tr1.Substring(0, ic1 - 1) 'in hr
            tr5 = Mid(tr1, ic1 + 1)
        End If
        Return Trim(str2)
    End Function
    Public Shared Function fincheck(ByVal finyear As String, ByVal compdate As Date) As Integer
        Dim d1, d2 As Date
        Dim k, year As Integer
        k = 0
        year = divcut(finyear)
        d1 = "01/04/" & year
        d2 = "31/03/" & year + 1
        If compdate < d1 Or compdate > d2 Then
            k = 1
        End If
        Return k
    End Function
    Public Shared Function CreateConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function
    Public Shared Function OpenConnection() As SqlConnection
        Dim conn As SqlConnection = CreateConnection()
        conn.Open()
        Return conn
    End Function
    Public Shared Function GetDA(ByVal tsql As String) As SqlClient.SqlDataAdapter ' OleDb.OleDbDataAdapter
        Dim conn As SqlConnection = CreateConnection()
        If tsql = Nothing Then
            Throw (New ArgumentNullException("text"))
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlClient.SqlCommand(tsql, conn)
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        conn.Close()
        Return da
    End Function
    Private Shared Function CreateCommand(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal text As String, ByVal ParamArray args As Object()) As SqlCommand
        Dim cmd As SqlCommand = conn.CreateCommand()
        If args IsNot Nothing AndAlso args.Length <> 0 Then
            Dim argnames As Object() = New Object(args.Length - 1) {}
            For i As Integer = 0 To args.Length - 1
                Dim name As String = "@AutoArg" & Convert.ToString(i + 1)
                argnames(i) = name
                cmd.Parameters.AddWithValue(name, args(i))
            Next
            text = String.Format(text, argnames)
        End If
        cmd.Connection = conn
        cmd.Transaction = trans
        cmd.CommandText = text
        Return cmd
    End Function
    Public Shared Function ExecuteDataSet(ByVal text As String, ByVal ParamArray args As Object()) As DataSet
        Dim Str As String = text
        Dim adp As New SqlDataAdapter(Str, OpenConnection())
        Dim ds As New DataSet
        adp.Fill(ds)
        Return ds
    End Function
    Public Shared Function CreateCommand(ByVal conn As SqlConnection, ByVal text As String, ByVal ParamArray args As Object()) As SqlCommand
        If conn Is Nothing Then
            Throw (New ArgumentNullException("conn"))
        End If
        If text Is Nothing Then
            Throw (New ArgumentNullException("text"))
        End If
        Return CreateCommand(conn, Nothing, text, args)
    End Function

    Public Shared Function bindcombo(ByVal str As String, ByVal fieldval As String, ByVal fieldtest As String, ByVal ddldrop As DropDownList) As String
        Dim dsdrop As New DataSet
        GetDA(str).Fill(dsdrop, "a")
        If dsdrop.Tables("a").Rows.Count > 0 Then
            ddldrop.DataSource = dsdrop.Tables("a")
            ddldrop.DataTextField = fieldtest
            ddldrop.DataValueField = fieldval
            ddldrop.DataBind()
        End If
        dsdrop.Tables("a").Clear()
        Return False
    End Function

    Public Shared Function bindgrid(ByVal str As String, ByVal ddgrid As GridView) As String
        Dim dsdrop As New DataSet
        GetDA(str).Fill(dsdrop, "a")
        If dsdrop.Tables("a").Rows.Count > 0 Then
            ddgrid.DataSource = dsdrop.Tables("a")
            ddgrid.DataBind()
            ddgrid.Visible = True
        Else
            ddgrid.Visible = False
        End If
        dsdrop.Tables("a").Clear()
        Return False
    End Function

    Public Shared Function CreateCommand(ByVal trans As SqlTransaction, ByVal text As String, ByVal ParamArray args As Object()) As SqlCommand
        If trans Is Nothing Then
            Throw (New ArgumentNullException("trans"))
        End If
        If text Is Nothing Then
            Throw (New ArgumentNullException("text"))
        End If
        Return CreateCommand(trans.Connection, trans, text, args)
    End Function

#Region "No Transaction"
    Public Shared Function ExecuteReader(ByVal text As String, ByVal ParamArray args As Object()) As SqlDataReader
        If text Is Nothing Then
            Throw (New ArgumentNullException("text"))
        End If
        Dim conn As SqlConnection = CreateConnection()
        Dim cmd As SqlCommand = CreateCommand(conn, text, args)
        conn.Open()
        Return cmd.ExecuteReader(CommandBehavior.CloseConnection)
    End Function
    Public Shared Sub ExecuteNonQuery(ByVal text As String, ByVal ParamArray args As Object())
        If text Is Nothing Then
            Throw (New ArgumentNullException("text"))
        End If
        Using conn As SqlConnection = OpenConnection()
            Dim cmd As SqlCommand = CreateCommand(conn, text, args)
            cmd.ExecuteNonQuery()
        End Using
    End Sub
    Public Shared Function ExecuteNonQuery1(ByVal text As String, ByVal ParamArray args As Object()) As Integer
        If text Is Nothing Then
            Throw (New ArgumentNullException("text"))
        End If
        Using conn As SqlConnection = OpenConnection()
            Dim cmd As SqlCommand = CreateCommand(conn, text, args)
            Return cmd.ExecuteNonQuery()
        End Using
    End Function
    Public Shared Function ExecuteScalar(ByVal text As String, ByVal ParamArray args As Object()) As Object
        If text Is Nothing Then
            Throw (New ArgumentNullException("text"))
        End If
        Using conn As SqlConnection = OpenConnection()
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd As SqlCommand = CreateCommand(conn, text, args)
            Return cmd.ExecuteScalar()
            conn.Close()
        End Using
    End Function

    Public Shared Function ExecuteInt32(ByVal text As String, ByVal ParamArray args As Object()) As Integer
        Return Convert.ToInt32(ExecuteScalar(text, args))
    End Function
    Public Shared Function ExecuteString(ByVal text As String, ByVal ParamArray args As Object()) As String
        Dim obj As Object = ExecuteScalar(text, args)
        If obj Is Nothing Then
            Return Nothing
        End If
        Return obj.ToString()
    End Function

    Public Shared Function ExecuteDataTable(ByVal text As String, ByVal ParamArray args As Object()) As DataTable
        Using reader As SqlDataReader = ExecuteReader(text, args)
            Dim table As New DataTable()
            table.Load(reader)
            Return table
        End Using
    End Function
    Public Shared Function ExecuteDataRow(ByVal text As String, ByVal ParamArray args As Object()) As DataRow
        Return GetDataRow(ExecuteDataTable(text, args), False)
    End Function
    Public Shared Function ExecuteDataRow(ByVal checkOnlyOne As Boolean, ByVal text As String, ByVal ParamArray args As Object()) As DataRow
        Return GetDataRow(ExecuteDataTable(text, args), checkOnlyOne)
    End Function
#End Region

    Public Shared Function GetDataRow(ByVal table As DataTable, ByVal checkOnlyOne As Boolean) As DataRow
        If table Is Nothing Then
            Throw (New ArgumentNullException("table"))
        End If
        Dim rc As Integer = table.Rows.Count
        If checkOnlyOne AndAlso rc <> 1 Then
            If rc = 0 Then
                Throw (New Exception("Table contains no row"))
            End If
            Throw (New Exception("Table contains multi row"))
        End If
        If rc = 0 Then
            Return Nothing
        End If
        Return table.Rows(0)
    End Function
    Public Shared ReadOnly Property Context() As HttpContext
        Get
            Return HttpContext.Current
        End Get
    End Property

    Public Shared Function GetCommonAutoID(ByVal str As Object) As Integer
        Return CType(ExecuteScalar(str), Integer) + 1
    End Function
    'Public Function GetCommonAutoID(ByVal sql As String) As Integer
    '    Dim cmd As New OleDb.OleDbCommand(sql, con)
    '    Dim da As New OleDb.OleDbDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    Dim AutoID As Int64
    '    da.Fill(ds, "AutoID")
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        AutoID = Convert.ToInt64(ds.Tables(0).Rows(0)(0)) + 1
    '    Else
    '        AutoID = 1
    '    End If
    '    Return AutoID
    'End Function

    Public Shared Function GetServerDateTime() As DateTime
        Dim dt As New DataTable

        dt = ExecuteDataTable("Select getdate()")
        GetServerDateTime = dt.Rows(0).Item(0)
    End Function

    Public Shared Function LogOutUser(ByVal E_ID As String, ByVal E_Name As String) As String
        Dim dtDep, dtTemp, dtTime As New DataTable
        Dim dDate As Date
        Dim tDepTime As DateTime
        Dim sOBT As String

        LogOutUser = ""
        dDate = Format(SQL_DB.GetServerDateTime, "yyyy/MM/dd")
        If UCase(E_Name) <> "SUPER" Then

            dtTemp = ExecuteDataTable("Select * from M_HR_EMP Where E_Id='" & E_ID & "'")
            If dtTemp.Rows.Count <> 0 Then
                dtDep = ExecuteDataTable("Select * from T_HR_ATTENDANCE Where EntDate='" & Format(dDate, "yyyy/MM/dd") & "' And E_ID='" & dtTemp.Rows(0).Item("E_ID") & "'")
                If dtDep.Rows.Count <> 0 Then
                    If dtDep.Rows(0).Item("Leave").ToString <> "L" Then
                        dtTime = ExecuteDataTable("Select * from M_OFFICE_TIMING Order By O_TI_ID Desc")
                        If dtDep.Rows.Count = 0 Then
                            LogOutUser = "Ask Administrator to Set Office Timing"
                            Exit Function
                        Else
                            tDepTime = Format(dtTime.Rows(0).Item("Leave_Time"), "hh:mm tt")
                        End If
                        Dim Time As DateTime = Format(SQL_DB.GetServerDateTime, "hh:mm tt")

                        If Int(DateDiff("s", Format(Time, "hh:mm tt"), Format(tDepTime, "hh:mm tt")) / 60) > 0 Then sOBT = "Y" Else sOBT = "N"
                        dtTime.Clear()
                        dtTime = ExecuteDataTable("Update T_HR_ATTENDANCE Set Departure_Time='" & Format(Time, "hh:mm tt") & "' , OBT='" & sOBT & "' , OBT_Reason='" & Format(Time, "hh:mm tt") & "' Where EntDate='" & Format(dDate, "yyyy/MM/dd") & "' And E_ID='" & E_ID & "'")
                    End If
                Else
                    LogOutUser = "User Not Found in Login Details."
                    Exit Function
                End If

            End If
        End If
    End Function
    Public Shared Function CheckAvailability(ByVal Pro_Id As String) As Integer
        Dim i As Integer = SQL_DB.ExecuteScalar("select [Product_Qty] from [Product_Master] where [Produt_Code]='" & Pro_Id & "'")
        Return i
    End Function
End Class
