namespace AOP
{
    public interface IProxy
    {
        bool IsEnabled();
        void Open();
        void Close();
    }

    public class Proxy : IProxy
    {
        public bool IsEnabled()
        {
            return true;
        }

        public void Open()
        {
            return;
        }

        public void Close()
        {
            return;
        }
    }
}
