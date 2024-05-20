/**********************************************************
文件：FanshapedRange.cs
作者：auus
邮箱：#Email#
日期：2023/03/06 17:04:39
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 扇形区域
/// </summary>
public class FanshapedRange : SectorRange
{
    public FanshapedRange(float radius, float degree) : base(radius, 0, degree)
    {
    }

    //扇形最后一个三角形不需要闭环
    public override void DrawRange(Transform transform, Mesh mesh, MeshRenderer renderer)
    {
        //分区个数
        int segments = (int)Degree;
        //确定绘制点的个数
        int verticesLen = segments + 2;
        //角度变为弧度制
        float radian = Degree * Mathf.Deg2Rad;
        //定义需要用到的值，自左向右绘制
        float curRadian = Mathf.PI / 2 + radian / 2;
        float deltaRadian = radian / verticesLen;

        //定义图形的顶点
        Vector3[] vertices = new Vector3[verticesLen];
        //第一个顶点为圆心
        vertices[0] = Vector3.zero;
        //保存其余圆上的点
        for (int i = 1; i < verticesLen - 1; i++)
        {
            float cos = Mathf.Cos(curRadian);
            float sin = Mathf.Sin(curRadian);
            vertices[i] = new Vector3(cos * Radius, 0, sin * Radius);
            //角度递增
            curRadian -= deltaRadian;
        }

        //由于浮点数存在误差，最后一个点直接设置为目标点
        curRadian = Mathf.PI / 2 - radian / 2;
        vertices[verticesLen - 1] = new Vector3(Mathf.Cos(curRadian) * Radius, 0, Mathf.Sin(curRadian) * Radius);

        //三角形点的个数
        int triangleCount = segments * 3;
        //定义点的绘制顺序
        int[] triangles = new int[triangleCount];
        for (int i = 0, j = 1; j < verticesLen - 1; i += 3, j++)
        {
            //以圆心为三角形第一个顶点
            triangles[i] = 0;
            triangles[i + 1] = j;
            triangles[i + 2] = j + 1;
        }



        ////最后一个三角形形成闭环
        //triangles[triangleCount - 3] = 0;
        //triangles[triangleCount - 2] = verticesLen - 1;
        //triangles[triangleCount - 1] = 1;

        //根据顶点位置设置纹理坐标
        Vector2[] uv = new Vector2[verticesLen];
        for (int i = 0; i < verticesLen; i++)
        {
            uv[i] = new Vector2(vertices[i].x / Radius / 2 + 0.5f, vertices[i].z / Radius / 2 + 0.5f);
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        renderer.material.color = Color.red;
    }
}
