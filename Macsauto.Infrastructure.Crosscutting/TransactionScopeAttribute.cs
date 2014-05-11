using System;
using System.Reflection;
using PostSharp.Aspects;

namespace Macsauto.Infrastructure.Crosscutting
{
    [Serializable]
    public class TransactionScopeAttribute : IOnMethodBoundaryAspect
    {
        public void RuntimeInitialize(MethodBase method)
        {
            throw new System.NotImplementedException();
        }

        public void OnEntry(MethodExecutionArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void OnExit(MethodExecutionArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void OnSuccess(MethodExecutionArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void OnException(MethodExecutionArgs args)
        {
            throw new System.NotImplementedException();
        }
    }
}