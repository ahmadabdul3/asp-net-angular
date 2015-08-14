using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MesjidCommittee.Helpers
{
    public class Global
    {

        public static string[] CommunityActivitiesList = { "Darul Quran", "Girls Club", "Sunday School", "Other" };
    }
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
    public class ServerResponse <T1, T2, T3>
    {
        public T1 status { get; set; }
        public T2 message { get; set; }
        public T3 data { get; set; }
        public ServerResponse(T1 status, T2 message, T3 data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}