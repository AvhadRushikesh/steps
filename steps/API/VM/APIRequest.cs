//using static Steps_Utility.Class1;

using static steps.API.Type.SD;

namespace steps.API.VM
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }
    }
}