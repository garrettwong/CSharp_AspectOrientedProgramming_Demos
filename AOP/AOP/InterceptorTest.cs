using Microsoft.Practices.Unity;
using System;

namespace AOP
{
    public class InterceptorTest
    {
        public static void AOP_DiagnosticInterceptor_Test()
        {
            //https://hmadrigal.wordpress.com/2010/12/25/aspect-oriented-programming-and-interceptor-design-pattern-with-unity-2/
            // Loads the container
            IUnityContainer container = new UnityContainer();
            container = Microsoft.Practices.Unity.Configuration
                .UnityContainerExtensions.LoadConfiguration(container);

            // Resolve the proxy-sample
            var proxy = Microsoft.Practices.Unity
                .UnityContainerExtensions.Resolve<IProxy>(container);

            if (proxy.IsEnabled())
            {
                proxy.Open();
            }
            proxy.Close();

            // End of the test
            Console.ReadKey();
        }
    }
}
