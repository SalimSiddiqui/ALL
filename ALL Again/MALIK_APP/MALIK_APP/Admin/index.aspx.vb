Imports SQL_DB
Imports System.Data
Partial Class Admin_login1
    Inherits System.Web.UI.Page

    
    Private Sub loginB()
        Dim str As String
        str = "select typ from admin_login where user_id='" & TextBox3.Text.Replace("'", "") & "' and pwd='" & TextBox4.Text.Replace("'", "") & "' " '"select count(user_id) from admin_login where user_id='" & TextBox3.Text.Replace("'", "") & "' and pwd='" & TextBox4.Text.Replace("'", "") & "' and status=1 and Plan_id=2"
        Dim ds As New DataSet()
        SQL_DB.GetDA("select typ from admin_login where user_id='" & TextBox3.Text.Replace("'", "") & "' and pwd='" & TextBox4.Text.Replace("'", "") & "' and status=1 and typ='" & ddllogintyp.SelectedValue & "' ").Fill(ds, "1")
        Dim i As Integer = ds.Tables("1").Rows.Count
        If ds.Tables("1").Rows.Count > 0 Then
            Session.Add("u_reg", ds.Tables("1").Rows(0).Item(0).ToString)
            Session.Add("User_Id", TextBox3.Text)
            Session.Add("user", "sds")
            Session.Add("admin", "test")
            Session.Add("Type", ddllogintyp.SelectedValue)
            Session.Timeout = 40
            Response.Redirect("AddProperty.aspx")
        Else
            lbladminmsg.Text = "(Invalid User ID or Password)"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbladminmsg.Text = ""
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        loginB()
    End Sub
End Class
