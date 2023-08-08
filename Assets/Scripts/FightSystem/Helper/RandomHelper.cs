/**********************************************************
文件：RandomHelper.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 17:00:38
功能：Nothing
/**********************************************************/

using System;

public static class RandomHelper
{
    private static readonly Random random = new Random();

    public static int RandomNumber(int lower, int upper)
    {
        int value = random.Next(lower, upper);
        return value;
    }

    public static int RandomRate()
    {
        int value = random.Next(1, 101);
        return value;
    }
}
