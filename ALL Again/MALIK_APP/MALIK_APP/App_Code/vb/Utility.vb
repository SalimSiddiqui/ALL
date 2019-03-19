
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
Imports Microsoft.VisualBasic

Partial Public Class Utility

    Public Shared Function date_diff(ByVal sdate As DateTime, ByVal fdate As DateTime) As Integer
        Dim difmno As Integer
        difmno = DateDiff(DateInterval.Month, sdate, fdate)
        Return difmno
    End Function

End Class
