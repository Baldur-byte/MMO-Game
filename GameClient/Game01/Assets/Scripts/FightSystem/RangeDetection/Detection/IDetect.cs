/**********************************************************
文件：IDetect.cs
作者：auus
邮箱：#Email#
日期：2023/03/06 11:06:34
功能：Nothing
/**********************************************************/

using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class IDetect
{
    protected IRange range;
    public abstract bool IsInRange(Transform self, Vector3 target, bool isIgnoreY = true);

    public void DrawRange(Transform transform)
    {
        range.DrawRange(transform, transform.GetComponent<MeshFilter>().mesh, transform.GetComponent<MeshRenderer>());
    }
}
