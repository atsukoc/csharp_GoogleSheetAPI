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
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "My first dot net project";
        static String SpreadsheetId = "1_fY6TqTeUETqQR8zEks1mA1TpgsRBgkgJWp2KZtBPpQ";
        static String SheetName = "Sheet1";


        private static UserCredential GetCredential()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                Console.WriteLine("Credential file saved to: " + credPath);

            }

            return credential;
        }


        // Create Google Sheets API service.
        private static SheetsService CreateGoogleSheetService(ref UserCredential credential){
            
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }



        public static void WriteData(ref Person person)
        {
            UserCredential credential = GetCredential();
            SheetsService service = CreateGoogleSheetService(ref credential);
            String range = String.Format("{0}!A2:B", SheetName);

            int numOfRows = CountRows(service, range);
            Console.WriteLine("number of rows: " + numOfRows);


            /*
            string firstname = person.GetFirstName();
            string lastname = person.GetLastname();
            List<ValueRange> valueRanges = new List<ValueRange>();
            var rows = new List<IList<Object>>();
            var values = new List<Object>();
            values.Add(firstname);
            values.Add(lastname);
            rows.Add(values);
            

            // The A1 notiation of a range to search for a logical table of data
            String range = String.Format("{0}!A4:B", SheetName);

            // How the input data should be interpreted
            SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum valueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;

            // How the input data should be inserted
            SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum insertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;

            // 
            ValueRange requestBody = new ValueRange();
            requestBody.Range = range;
            requestBody.Values = rows;
            valueRanges.Add(requestBody);

            */

            service.Dispose();
                
        }

        private static int CountRows(SheetsService service, string range)
        {

            SpreadsheetsResource.ValuesResource.GetRequest getRequest =
                       service.Spreadsheets.Values.Get(SpreadsheetId, range);

            ValueRange getResponse = getRequest.Execute();
            IList<IList<Object>> getValues = getResponse.Values;


            return getValues.Count;
        }

        

        public static void ReadData()
        {
            UserCredential credential = GetCredential();

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
