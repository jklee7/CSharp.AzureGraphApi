An example demonstrating how to query Azure Active Directory in C#.

---

# Instructions
### Packages
The following packages need to be installed:
```
Microsoft.Graph
Microsoft.Identity.Client
Microsoft.IdentityModel.Clients.ActiveDirectory
```
### Azure Service Principal
This example uses an Azure Service Principal to connect to and query Azure AD.
You need to make sure you give the **Read directory data** permission in Azure AD.

---

### Useful References
- [Intro to the Microsoft Graph .NET Client Library][1]
- [Graph ASP.NET snippets][2]
- [Using Microsoft Graph API to interact with Azure AD][3]

[1]: http://www.jonathanhuss.com/intro-to-the-microsoft-graph-net-client-library/
[2]: https://github.com/microsoftgraph/aspnet-snippets-sample/blob/master/Graph-ASPNET-46-Snippets/Microsoft%20Graph%20ASPNET%20Snippets/Models/UsersService.cs
[3]: https://vincentlauzon.com/2017/01/31/using-microsoft-graph-api-to-interact-with-azure-ad/
