using System;

public interface ITypeFactory
{
    T Create<T>(params object[] extraArgs);
}

public class TypeFactoryMock : ITypeFactory
{
    public T Create<T>(params object[] extraArgs)
    {
        return Activator.CreateInstance<T>();
    }
}