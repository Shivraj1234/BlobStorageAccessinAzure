namespace AzureFunctionDemop
{
    internal class ServiceClient
    {
        private string connectionString;

        public ServiceClient(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static object service { get; internal set; }
        public bool IsReady { get; internal set; }
    }
}