/**********************************************************
文件：DrawArea.cs
作者：auus
邮箱：#Email#
日期：2023/03/07 11:32:27
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArea : MonoBehaviour
{
    private IDetect detect;

    public void Start()
    {
        //range = new TriangleRange(5, 5);

        //range = new RectangleRange(5, 5);

        //detect = new SectorDetect(3);
        //detect = new SectorDetect(3, 270);
        //detect = new SectorDetect(3, 2, true);
        detect = new SectorDetect(3, 2, 270);

        detect.DrawRange(transform);

        Debug.LogError(9 / 3 / 3);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Plane")
                {
                    Color color = detect.IsInRange(transform, hit.point) ? Color.green : Color.red;
                    Debug.DrawLine(Camera.main.transform.position, hit.point, color, 100);
                }
            }
        }
    }
}
