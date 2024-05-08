namespace Common
{
    public class Url
    {
        //public const string Api_Gateway = "https://localhost:5010";
        public const string Identity_Server = "https://localhost:5015";
        public const string Shopping_Api = "https://localhost:5001";
        public const string Shopping_Client = "https://localhost:5002";

        public const string Sign_In = Shopping_Client + "/signin-oidc";
        public const string Sign_Out = Shopping_Client + "/signout-callback-oidc";

        public const string Shopping = "/shopping";
    }
}
