using JetBrains.Annotations;
using System;

public interface ILogger
{
    string LoggerName { get; }

    [StringFormatMethod("messageFormat")]
    void Debug(Exception ex, string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Debug(string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Error(Exception ex, string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Error(string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Fatal(Exception ex, string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Fatal(string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Info(Exception ex, string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Info(string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Trace(Exception ex, string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Trace(string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Warning(Exception ex, string messageFormat, params object[] messageFormatArgs);

    [StringFormatMethod("messageFormat")]
    void Warning(string messageFormat, params object[] messageFormatArgs);
}

public class LoggerMock : ILogger
{
    public string LoggerName => string.Empty;

    public void Debug(Exception ex, string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.Log($"{string.Format(messageFormat, messageFormatArgs)}\n{ex}");
    }

    public void Debug(string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.LogFormat(messageFormat, messageFormatArgs);
    }

    public void Error(Exception ex, string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.LogError($"{string.Format(messageFormat, messageFormatArgs)}\n{ex}");
    }

    public void Error(string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.LogErrorFormat(messageFormat, messageFormatArgs);
    }

    public void Fatal(Exception ex, string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.LogError($"{string.Format(messageFormat, messageFormatArgs)}\n{ex}");
    }

    public void Fatal(string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.LogErrorFormat(messageFormat, messageFormatArgs);
    }

    public void Info(Exception ex, string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.Log($"{string.Format(messageFormat, messageFormatArgs)}\n{ex}");
    }

    public void Info(string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.LogFormat(messageFormat, messageFormatArgs);
    }

    public void Trace(Exception ex, string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.Log($"{string.Format(messageFormat, messageFormatArgs)}\n{ex}");
    }

    public void Trace(string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.LogFormat(messageFormat, messageFormatArgs);
    }

    public void Warning(Exception ex, string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.LogWarning($"{string.Format(messageFormat, messageFormatArgs)}\n{ex}");
    }

    public void Warning(string messageFormat, params object[] messageFormatArgs)
    {
        UnityEngine.Debug.LogWarningFormat(messageFormat, messageFormatArgs);
    }
}
