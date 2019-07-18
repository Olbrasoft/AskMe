using System;

namespace Olbrasoft.Dependence
{
    public interface IResolver
    {
        object Resolve(Type type);
    }
}