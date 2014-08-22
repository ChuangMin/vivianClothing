<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Upload</title>

</head>
<body>
    <div>
        
        <h2>Index</h2>
        
        <% using (Html.BeginForm("IMGUpload", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
           { %>

        select a file <input type="file" name="fileUpload" />

        <input type="submit" value="fileUpload" />

        <%  } %>
    </div>
</body>
</html>
