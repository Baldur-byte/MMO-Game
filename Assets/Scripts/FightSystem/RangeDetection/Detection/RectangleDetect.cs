/**********************************************************
文件：RectangleDetect.cs
作者：auus
邮箱：#Email#
日期：2023/03/06 11:06:11
功能：Nothing
/**********************************************************/

using UnityEngine;

/// <summary>
/// 矩形区域检测
/// </summary>
public class RectangleDetect : IDetect
{
    public RectangleDetect(float distance, float width)
    {
        range = new RectangleRange(distance, width);
    }

    public override bool IsInRange(Transform self, Vector3 target, bool isIgnoreY = true)
    {
        RectangleRange rectangle = range as RectangleRange;
        if (isIgnoreY)
        {
            //将目标点移动到统一平面
            target = CommonMethod.StandardlizedVectorY(target, self.position.y);
        }
        Vector3 dir = target - self.position;
        float dotFarward = Vector3.Dot(dir, self.forward);

        if (dotFarward > 0 && dotFarward <= rectangle.Distance)
        {
            float dotRight = Vector3.Dot(dir, self.right);
            if (Mathf.Abs(dotRight) < rectangle.Width / 2)
            {
                return true;
            }
        }
        return false;
    }
}
