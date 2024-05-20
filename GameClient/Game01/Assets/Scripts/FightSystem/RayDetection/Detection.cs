/**********************************************************
文件：Detection.cs
作者：auus
邮箱：#Email#
日期：2023/03/08 17:46:45
功能：Nothing
/**********************************************************/

using UnityEngine;

public class Detection : MonoBehaviour
{

    private Ray ray;
    private RaycastHit hit;

    private State state;

    public void Start()
    {
        ray = new Ray(transform.position - Vector3.up, Vector3.up);
        Debug.DrawRay(ray.origin, ray.direction, Color.green, 100);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction, Color.green, 100);

        state = new State();
    }

    public void Update()
    {
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.name == "Sphere")
            {
                Debug.Log(hit.collider.name);
            }
        }

        if (Look())
        {
            Debug.Log("Get It!");
        }
    }

    //检测区域内同时发射多条射线进行检测
    
    //放射线检测
    private bool Look()
    {
        //一条向前的射线
        if (LookAround(Quaternion.identity, Color.green))
            return true;

        //多一个精确度就多两条对称的射线,每条射线夹角是总角度除与精度
        float subAngle = (state.LookAngle()/ 2) / state.LookAccurate();
        for (int i = 0; i < state.LookAccurate(); i++)
        {
            if (LookAround(Quaternion.Euler(0, -1 * subAngle * (i + 1), 0), Color.green)
                || LookAround(Quaternion.Euler(0, subAngle * (i + 1), 0), Color.green))
                return true;
        }

        return false;
    }

    //射出射线检测是否有Player
    public bool LookAround(Quaternion eulerAnger, Color DebugColor)
    {
        Debug.DrawRay(transform.position, eulerAnger * transform.forward.normalized * state.LookDistance(), DebugColor);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, eulerAnger * transform.forward, out hit, state.LookDistance()) && hit.collider.CompareTag("Player"))
        {
            state.ChaseTarget(hit.transform);
            return true;
        }
        return false;
    }

    //只发射一条射线，每帧移动固定角度，在检测区域内循环转动

    //发射多条射线循环转动
}

public class State 
{
    public float LookAngle()
    {
        return 90;
    }

    public int LookAccurate()
    {
        return 1;
    }

    public float LookDistance()
    {
        return 10;
    }

    public void ChaseTarget(Transform transform)
    {

    }
}
