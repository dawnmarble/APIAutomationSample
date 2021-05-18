using RestSharp;

namespace APIAutomationSample.Helpers
{
    class APIHelper
    {
        public static RestSharp.Method PickAMethod(string method)
        {
            switch (method)
            {
                case "GET":
                    return Method.GET;

                case "PUT":
                    return Method.PUT;

                case "DELETE":
                    return Method.DELETE;

                default:
                    return Method.POST;
            }
        }
    }
}
