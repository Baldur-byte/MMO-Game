/**********************************************************
文件：RectangleRange.cs
作者：auus
邮箱：#Email#
日期：2023/03/06 10:50:59
功能：Nothing
/**********************************************************/

using UnityEngine;

/// <summary>
/// 矩形区域
/// </summary>
public class RectangleRange : IRange
{
    /// <summary>
    /// 矩形的长
    /// </summary>
    public float Distance;

    /// <summary>
    /// 矩形的宽
    /// </summary>
    public float Width;

    public RectangleRange(float distance, float width)
    {
        this.Distance = distance;
        this.Width = width;
    }

    public void DrawRange(Transform transform, Mesh mesh, MeshRenderer renderer)
    {
        //定义顶点
        Vector3 point1 = -transform.right * Width / 2;
        Vector3 point2 = -transform.right * Width / 2 + transform.forward * Distance;
        Vector3 point3 = transform.right * Width / 2 + transform.forward * Distance;
        Vector3 point4 = transform.right * Width / 2;
        //定义图片的四个顶点
        Vector3[] vertices = new Vector3[] { point1, point2, point3, point4 };
        //定义图片中顶点的顺序
        int[] triangles = new int[] { 0, 1, 2 , 2, 3, 0};

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        renderer.material.color = Color.red;
    }
}
