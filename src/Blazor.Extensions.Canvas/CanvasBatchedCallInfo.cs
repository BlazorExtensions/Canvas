namespace Blazor.Extensions
{
    public struct CanvasBatchedCallInfo
    {
        public string Call { get; }

        public string Name { get; }

        public object[] Parameters { get; }

        public CanvasBatchedCallInfo(string call, string name, object[] parameters = null)
        {
            this.Call = call;
            this.Name = name;
            this.Parameters = parameters;
        }
    }
}
