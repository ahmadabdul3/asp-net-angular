using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MesjidCommittee.Helpers.ServerResponse
{
    public class ErrorMessages
    {
        public static readonly string ErrorString = "Error:";
        public static readonly string SuccessString = "Success:";
        public static readonly string ErrMsg_RequiredFieldsWereEmpty = "Some required fields were empty.";
        public static readonly string ErrMsg_Generic = "Woops, something went wrong! Please try again.";

        public static ServerResponse<string, string, string> getErrorGenericServerResponse()
        {
            return new ServerResponse<string, string, string>(ErrorString, ErrMsg_Generic, null);
        }
        public static ServerResponse<string, string, string> getErrorFieldsEmptyServerResponse()
        {
            return new ServerResponse<string, string, string>(ErrorString, ErrMsg_RequiredFieldsWereEmpty, null);
        }
    }
}