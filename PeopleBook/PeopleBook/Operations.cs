using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PeopleBook
{
    public class Operations
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "My first dot net project";
        static String SpreadsheetId = "1_fY6TqTeUETqQR8zEks1mA1TpgsRBgkgJWp2KZtBPpQ";
        static String SheetName = "Sheet1";


        /************************************************************************
         * This method reads the credential file obtained from Google API and
         * returns the UserCredential object that is needed for SheetsService
         * **********************************************************************/
        private static UserCredential GetCredential()
        {
            UserCredential credential;

            using (var stream = new FileStream("/Users/Atsuko/git/csharp_people/PeopleBook/PeopleBook/credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return credential;
        }


        /************************************************************************
         * This method creates and returns the Google Sheets API service
         * **********************************************************************/
        private static SheetsService CreateGoogleSheetService(ref UserCredential credential)
        {
           var service = new SheetsService(new BaseClientService.Initializer()
           {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
           });

            return service;
        }


        /************************************************************************
        * This method writes the person's information (name, address, email address)
        * to the google sheet
        * **********************************************************************/
        public static void WriteData(ref Person person)
        {
            UserCredential credential = GetCredential();
            SheetsService service = CreateGoogleSheetService(ref credential);

            // find out the current number of rows in the spreadsheet
            String currentRange = String.Format("{0}!A1:B", SheetName);
            int rowIndex = CountRows(service, currentRange) + 1;

            // The A1 notation of the values to update
            string newRange = String.Format("{0}!A{1}:B{1}", SheetName, rowIndex);

            // How the input data should be interpreted
            SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum valueInputOption =
                SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

            // Create and set ValueRange. This is where you set the values to write to the google sheet.
            ValueRange requestBody = new ValueRange();
            string firstName = person.GetFirstName();
            string lastName = person.GetLastname();
            var values = new List<Object>() { firstName, lastName };
            requestBody.Values = new List<IList<Object>> { values };

            // Create UpdateRequest object
            SpreadsheetsResource.ValuesResource.UpdateRequest request = service.Spreadsheets.Values.Update(requestBody, SpreadsheetId, newRange);
            request.ValueInputOption = valueInputOption;

            // Execute the request and get the result
            UpdateValuesResponse result = request.Execute();

            Console.WriteLine("\nData added successfully");
            Console.WriteLine(String.Format("Number of rows added: {0}", result.UpdatedRows));

            service.Dispose();
                
        }

        /************************************************************************
        * This method counts and returns the number of rows in the google sheet
        ***********************************************************************/
        private static int CountRows(SheetsService service, string range)
        {

            SpreadsheetsResource.ValuesResource.GetRequest getRequest =
                       service.Spreadsheets.Values.Get(SpreadsheetId, range);

            ValueRange getResponse = getRequest.Execute();
            IList<IList<Object>> getValues = getResponse.Values;


            return getValues.Count;
        }


        /************************************************************************
        * This method displays all the rows in the google sheet
        * **********************************************************************/
        public static void ReadData()
        {
            UserCredential credential = GetCredential();
            Console.WriteLine(credential.ToString());

            // Define request parameters.
            SheetsService service = CreateGoogleSheetService(ref credential);
            String range = String.Format("{0}!A2:B", SheetName);
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(SpreadsheetId, range);

            // Prints the values from the spreadsheet

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    Console.WriteLine("Name | {0} {1}", row[0], row[1]);
                    
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            service.Dispose();
        }
    }
    
}
