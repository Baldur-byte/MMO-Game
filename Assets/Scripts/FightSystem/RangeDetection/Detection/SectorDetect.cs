/**********************************************************
文件：SectorDetect.cs
作者：auus
邮箱：#Email#
日期：2023/03/06 11:07:27
功能：Nothing
/**********************************************************/

using UnityEngine;
/// <summary>
/// 扇形区域检测
/// </summary>
public class SectorDetect : IDetect
{
    public SectorDetect(float radius, float minRadius, float degree)
    {
        range = new SectorRange(radius, minRadius, degree);
    }

    public SectorDetect(float radius, float minRadius, bool hasMinRadius)
    {
        range = new RingRange(radius, minRadius);
    }

    public SectorDetect(float radius, float degree)
    {
        range = new FanshapedRange(radius, degree);
    }

    public SectorDetect(float radius)
    {
        range = new RoundRange(radius);
    }

    public override bool IsInRange(Transform self, Vector3 target, bool isIgnoreY = true)
    {
        SectorRange sector = range as SectorRange;
        if (isIgnoreY)
        {
            //将目标点移动到统一平面
            target = CommonMethod.StandardlizedVectorY(target, self.position.y);
        }
        Vector3 dir = target - self.position;

        //点乘dir 和 自身forward向量的单位向量，得到cos角度
        float dot = Vector3.Dot(self.forward, dir.normalized);

        //通过反三角函数转换为夹角弧度，并转化为角度
        float radian = Mathf.Acos(dot);
        float degree = Mathf.Rad2Deg * radian;

        if (dir.magnitude <= sector.Radius && dir.magnitude > sector.MinRadius && degree < sector.Degree / 2)
        {
            return true;
        }
        return false;
    }
}
