using System;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Graph;

namespace CSharp.AzureGraphApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Constants
            var tenant = "myActiveDirectory.onmicrosoft.com";
            var resource = "https://graph.microsoft.com/";
            var clientID = "[service principal application id]";
            var secret = "[service principal secret key]";
        
            //  Ceremony
            var authority = $"https://login.microsoftonline.com/{tenant}";
            var authContext = new AuthenticationContext(authority);
            var credentials = new ClientCredential(clientID, secret);
            var authResult = authContext.AcquireTokenAsync(resource, credentials).Result;

            // Create Microsoft Graph client.
            var graphClient = new GraphServiceClient("https://graph.microsoft.com/v1.0",
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("bearer", authResult.AccessToken);
                        // This header has been added to identify our sample in the Microsoft Graph service.  If extracting this code for your project please remove.
                        requestMessage.Headers.Add("SampleID", "uwp-csharp-connect-sample");

                    }));


            // Get default user attributes
            // By default, only a limited set of properties are returned
            // ( businessPhones, displayName, givenName, id, jobTitle, mail, mobilePhone, officeLocation, preferredLanguage, surname, userPrincipalName )
            var result = graphClient.Users["username@myorg.com"].Request().GetAsync().Result;
            Console.WriteLine($"User details: {result.DisplayName}, {result.GivenName}, {result.JobTitle}");

            // Get user attributes using optional query parameters
            // https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_get#optional-query-parameters
            var resultWithOptionalQuery = graphClient.Users["username@myorg.com"].Request().Select("AccountEnabled").GetAsync().Result;
            Console.WriteLine($"User details: {result.DisplayName}, {result.AccountEnabled}");
            

            Console.ReadKey();
        }
    }
}