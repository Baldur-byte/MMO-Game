/**********************************************************
文件：CommonMethod.cs
作者：auus
邮箱：#Email#
日期：2023/02/28 14:12:21
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMethod
{
    public static float GetHorizonDistance(Vector3 from, Vector3 to)
    {
        return Vector3.Distance(new Vector3(from.x, 0, from.z), new Vector3(to.x, 0, to.z));
    }

    public static Vector3 StandardlizedVectorY(Vector3 vector, float y = 0)
    {
        return new Vector3(vector.x, y, vector.z);
    }
}
