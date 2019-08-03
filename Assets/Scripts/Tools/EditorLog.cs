using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

/// <summary>
/// UnityEditorでのみDebug.Logの処理を行うクラス
/// </summary>
public static class EditorLog
{
    /// <summary>
    /// 通常ログ
    /// </summary>
    /// <param name="message">メッセージ</param>
    [Conditional("UNITY_EDITOR")]
    public static void Default(object message)
    {
        Debug.Log(message);
    }

    /// <summary>
    /// カラー指定ログ
    /// </summary>
    /// <param name="message">メッセージ</param>
    /// <param name="color">カラー</param>
    [Conditional("UNITY_EDITOR")]
    public static void Color(object message, Color color)
    {
        var colorCode = ColorUtility.ToHtmlStringRGBA(color);
        Debug.LogFormat("<color=#{0}>{1}</color>", colorCode, message);
    }

    /// <summary>
    /// カラー指定ログ
    /// </summary>
    /// <param name="message">メッセージ</param>
    /// <param name="colorCode">カラーコード #不要</param>
    [Conditional("UNITY_EDITOR")]
    public static void Color(object message, string colorCode)
    {
        Debug.LogFormat("<color=#{0}>{1}</color>", colorCode, message);
    }

    /// <summary>
    /// 警告ログ
    /// </summary>
    /// <param name="message">メッセージ</param>
    [Conditional("UNITY_EDITOR")]
    public static void Warning(object message)
    {
        Debug.LogWarning(message);
    }

    /// <summary>
    /// エラーログ
    /// </summary>
    /// <param name="message">メッセージ</param>
    [Conditional("UNITY_EDITOR")]
    public static void Error(object message)
    {
        Debug.LogError(message);
    }

    /// <summary>
    /// 例外ログ
    /// </summary>
    /// <param name="exception">例外</param>
    [Conditional("UNITY_EDITOR")]
    public static void Exception(Exception exception)
    {
        Debug.LogException(exception);
    }
}
