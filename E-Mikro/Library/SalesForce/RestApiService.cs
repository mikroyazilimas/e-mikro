using E_Mikro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.DropboxLibraries.RestSharp;

namespace E_Mikro.Library
{
    public class RestApiService
    {
        public Output_DemoRequest DemoRequestForm(Input_RequestForm inpt)
        {   
            Output_Token outToken = new Output_Token();
            outToken = GetToken();
            InputHeader inputHeader = new InputHeader()
            {
                Token = false,
                Authorization = String.Format("{0} {1}", outToken.token_type, outToken.access_token)
            };
            return new RestProcess<Output_DemoRequest>() { WSName = Const.WSSalesforceUrl, InputClass = inpt, Type = Method.POST, InputMode = InputMode.Class, inputHeader = inputHeader }.Get();
        }

        public Output_Token GetToken()
        {
            string str = String.Format("grant_type={0}&client_id={1}&client_secret={2}&username={3}&password={4}", Names.WSSettings.grant_type, Names.WSSettings.client_id, Names.WSSettings.client_secret, Names.WSSettings.username, Names.WSSettings.password);
            return new RestProcess<Output_Token>().HttpRequest(Const.WSSalesforceUrlToken, Method.POST, str);
        }
    }
}