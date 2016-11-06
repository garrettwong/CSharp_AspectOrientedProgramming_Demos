﻿using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;

namespace AOP
{
    /// <summary>
    /// Unity Interceptors
    /// http://www.bardev.com/2011/03/21/aop-policy-injection-with-unity/
    /// </summary>
    public class DiagnosticInterceptor : IInterceptionBehavior
    {
        public DiagnosticInterceptor()
        {
            
        }

        /// <summary>
        /// Invoke interceptor on the IAOPBase interface
        /// </summary>
        /// <param name="input"></param>
        /// <param name="getNext"></param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            System.Console.WriteLine(String.Format("[{0}:{1}]", this.GetType().Name, "Invoke"));

            // PRE: BEFORE the target method execution
            System.Console.WriteLine(String.Format("{0}", input.MethodBase.ToString()));

            // EXE: Yield to the next module in the pipeline
            var methodReturn = getNext().Invoke(input, getNext);

            // POST: AFTER the target method execution
            if (methodReturn.Exception == null)
            {
                System.Console.WriteLine(String.Format("Successfully finished {0}", input.MethodBase.ToString()));
            }
            else
            {
                System.Console.WriteLine(String.Format("Finished {0} with exception {1}: {2}", input.MethodBase.ToString(), methodReturn.Exception.GetType().Name, methodReturn.Exception.Message));
            }

            return methodReturn;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            System.Console.WriteLine(String.Format("[{0}:{1}]", this.GetType().Name, "GetRequiredInterfaces"));
            return Type.EmptyTypes; 
        }

        public bool WillExecute
        {
            get
            {
                System.Console.WriteLine(String.Format("[{0}:{1}]", this.GetType().Name, "WillExecute"));
                return true;
            }
        }
    }
}
