/**********************************************************
文件：TriangleRange.cs
作者：auus
邮箱：#Email#
日期：2023/03/06 17:02:56
功能：Nothing
/**********************************************************/

using UnityEngine;

/// <summary>
/// 三角形区域
/// </summary>
public class TriangleRange : IRange
{
    /// <summary>
    /// 三角形的底边宽度
    /// </summary>
    public float Width;

    /// <summary>
    /// 三角形的高度
    /// </summary>
    public float Height;

    public TriangleRange(float width, float height)
    {
        Width = width;
        Height = height;
    }

    public void DrawRange(Transform transform, Mesh mesh, MeshRenderer renderer)
    {
        //定义顶点
        Vector3 point1 = - transform.right * Width / 2;
        Vector3 point2 = transform.forward * Height;
        Vector3 point3 = transform.right * Width / 2;
        //定义图片的三个顶点
        Vector3[] vertices = new Vector3[] { point1, point2, point3 };
        //定义图片中顶点的顺序
        int[] triangles = new int[] {0, 1, 2};

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        renderer.material.color = Color.red;
    }
}
