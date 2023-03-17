/**********************************************************
文件：Log.cs
作者：auus
邮箱：#Email#
日期：2023/03/16 11:32:07
功能：Nothing
/**********************************************************/

using System;

public static class Log
{
    public static void Message(string log)
    {
        UnityEngine.Debug.Log(log);
    }

    public static void Error(string log)
    {
        UnityEngine.Debug.LogError(log);
    }

    public static void Error(Exception e)
    {
        UnityEngine.Debug.LogException(e);
    }
}
