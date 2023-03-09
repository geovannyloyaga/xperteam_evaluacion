namespace xperteam.api.Utility
{
    public class Response<T>
    {
        #region Properties
        public bool status { get; set; }

        public T data { get; set; }

        public string message { get; set; }
        #endregion

        #region Constructor
        public Response(bool status, T data, string message)
        {
            this.status = status;
            this.data = data;
            this.message = message;
        }
        #endregion
    }
}
