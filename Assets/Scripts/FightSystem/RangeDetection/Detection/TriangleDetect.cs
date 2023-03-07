/**********************************************************
文件：TriangleDetect.cs
作者：auus
邮箱：#Email#
日期：2023/03/06 17:57:49
功能：Nothing
/**********************************************************/

using UnityEngine;

/// <summary>
/// 三角形区域检测
/// </summary>
public class TriangleDetect : IDetect
{
    public TriangleDetect(float width, float height)
    {
        range = new TriangleRange(width, height);
    }

    public override bool IsInRange(Transform self, Vector3 target, bool isIgnoreY = true)
    {
        TriangleRange triangle = range as TriangleRange;
        if (isIgnoreY)
        {
            //将目标点移动到统一平面
            target = CommonMethod.StandardlizedVectorY(target, self.position.y);
        }
        //三角形的三个端点 A. B . C
        Vector3 point1 = self.position - self.right * triangle.Width / 2;
        Vector3 point2 = self.position + self.forward * triangle.Height;
        Vector3 point3 = self.position + self.right * triangle.Width / 2;

        //要计算的目标点 P
        Vector3 pointP = target;

        return pointInTriangle(point1, point2, point3, pointP);
    }

    private bool pointInTriangle(Vector3 PointA, Vector3 PointB, Vector3 PointC, Vector3 PointP)
    {
        Vector3 vectorAC = PointC - PointA;
        Vector3 vectorAB = PointB - PointA;
        Vector3 vectorAP = PointP - PointA;

        //对于平面内任意一点可以用向量AB和AC来表示
        //P = A +  u * (C – A) + v * (B - A)
        //得到方程
        //AP = u * AC + v * AB
        //如果u或v为负，则P在AC，AB的反方向
        //若P位于三角形内部，则满足下面三个条件
        //u >= 0, v >= 0, u + v <= 1
        //左右两边同乘 AC 或 AB得到方程组
        //AP * AB = (u * AC + v * AB) * AB
        //AP * AC = (u * AC + v * AB) * AC
        //这里面u,v是数，AB,AC,AP是向量，所以可以用点积展开
        //AP * AB = u * AC *AB + v * AB * AB
        //AP * AC = u * AC *AC + v * AB * AC
        //解方程组，得
        //u = ((AB * AB) * (AC * AP) - (AB * AC) * (AP * AB)) / ((AB * AB)(AC * AC) - (AB * AC)(AC * AB))
        //v = ((AP * AB) * (AC * AC) - (AP * AC) * (AC * AB)) / ((AB * AB)(AC * AC) - (AB * AC)(AC * AB))

        //计算点乘积
        float dotABAB = Vector3.Dot(vectorAB, vectorAB);
        float dotABAC = Vector3.Dot(vectorAB, vectorAC);
        float dotABAP = Vector3.Dot(vectorAB, vectorAP);
        float dotACAC = Vector3.Dot(vectorAC, vectorAC);
        float dotACAP = Vector3.Dot(vectorAC, vectorAP);
        float dotAPAP = Vector3.Dot(vectorAP, vectorAP);

        float u = (dotABAB * dotACAP - dotABAC * dotABAP) / (dotABAB * dotACAC - dotABAC * dotABAC);
        float v = (dotABAP * dotACAC - dotACAP * dotABAC) / (dotABAB * dotACAC - dotABAC * dotABAC);

        Debug.Log("v : " + v);
        Debug.Log("u : " + u);
        Debug.Log("u + v <= 1 : " + (u + v <= 1).ToString());

        if (v >= 0 && u >= 0 && u + v <= 1)
        {
            return true;
        }

        return false;
    }
}
