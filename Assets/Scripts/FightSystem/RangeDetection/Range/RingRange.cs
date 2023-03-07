/**********************************************************
文件：RingRange.cs
作者：auus
邮箱：#Email#
日期：2023/03/06 17:04:55
功能：Nothing
/**********************************************************/

using UnityEngine;
/// <summary>
/// 环形区域
/// </summary>
public class RingRange : SectorRange
{
    public RingRange(float radius, float minRadius) : base(radius, minRadius, 360)
    {
    }

    //圆环需要闭环
    public override void DrawRange(Transform transform, Mesh mesh, MeshRenderer renderer)
    {
        //分区个数
        int segments = (int)Degree;
        //确定绘制点的个数
        int verticesLen = segments * 2;
        //角度变为弧度制
        float radian = Degree * Mathf.Deg2Rad;
        //定义需要用到的值，自左向右绘制
        float curRadian = Mathf.PI / 2 + (radian / 2);
        float deltaRadian = radian / segments;

        //定义图形的顶点
        Vector3[] vertices = new Vector3[verticesLen];
        for (int i = 0; i < verticesLen - 2; i += 2)
        {
            float cos = Mathf.Cos(curRadian);
            float sin = Mathf.Sin(curRadian);
            vertices[i] = new Vector3(cos * MinRadius, 0, sin * MinRadius);
            vertices[i + 1] = new Vector3(cos * Radius, 0, sin * Radius);
            //角度递增
            curRadian -= deltaRadian;
        }
        //三角形点的个数，一个分区需要两个三角形填充
        int triangleCount = segments * 6;
        //定义点的绘制顺序
        int[] triangles = new int[triangleCount];
        for (int i = 0, j = 0; j < triangleCount - 5; i += 2, j += 6)
        {
            //三角形一
            triangles[j] = i;
            triangles[j + 1] = i + 1;
            triangles[j + 2] = i + 3;

            //三角形二
            triangles[j + 3] = i + 3;
            triangles[j + 4] = i + 2;
            triangles[j + 5] = i;
        }

        //最后一个矩形闭环
        //三角形一
        triangles[triangleCount - 6] = verticesLen - 4;
        triangles[triangleCount - 5] = verticesLen - 3;
        triangles[triangleCount - 4] = 1;

        //三角形二
        triangles[triangleCount - 3] = 1;
        triangles[triangleCount - 2] = 0;
        triangles[triangleCount - 1] = verticesLen - 4;

        //根据顶点位置设置纹理坐标
        Vector2[] uv = new Vector2[verticesLen];
        for (int i = 0; i < verticesLen - 1; i += 2)
        {
            uv[i] = new Vector2(i / segments, 0);
            uv[i + 1] = new Vector2(i / segments, 1);
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        renderer.material.color = Color.red;
    }
}
