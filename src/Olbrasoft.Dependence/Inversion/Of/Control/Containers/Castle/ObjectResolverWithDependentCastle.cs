using System;
using Castle.MicroKernel;

namespace Olbrasoft.Dependence.Inversion.Of.Control.Containers.Castle
{
    public class ObjectResolverWithDependentCastle : IResolver
    {
        protected IKernelInternal KernelInternal { get; }

        public ObjectResolverWithDependentCastle(IKernelInternal kernelInternal)
        {
            KernelInternal = kernelInternal;
        }

        public object Resolve(Type type)
        {
            return KernelInternal.Resolve(type);
        }
    }
}