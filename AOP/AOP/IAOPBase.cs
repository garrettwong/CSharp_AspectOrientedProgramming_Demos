namespace AOP
{
    /// <summary>
    /// The IAOPBase interface
    /// 
    /// Each of the methods in this interface will be logged via aspect oriented programming.  
    /// This is configured in the App.config file
    /// </summary>
    public interface IAOPBase
    {
        bool IsEnabled();
        void Open();
        void Close();
        void Hello();
    }
}
