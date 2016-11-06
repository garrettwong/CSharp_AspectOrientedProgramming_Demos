using Microsoft.Practices.Unity;
using System;

namespace AOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://hmadrigal.wordpress.com/2010/12/25/aspect-oriented-programming-and-interceptor-design-pattern-with-unity-2/
            // Loads the container
            IUnityContainer container = new UnityContainer();
            container = Microsoft.Practices.Unity.Configuration
                .UnityContainerExtensions.LoadConfiguration(container);

            // Resolve the proxy-sample
            var proxy = Microsoft.Practices.Unity
                .UnityContainerExtensions.Resolve<IAOPBase>(container);

            if (proxy.IsEnabled())
            {
                proxy.Open();
                proxy.Hello();
            }
            proxy.Close();

            // End of the test
            Console.ReadKey();
        }
    }
}
