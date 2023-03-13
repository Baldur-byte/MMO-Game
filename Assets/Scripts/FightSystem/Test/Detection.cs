/**********************************************************
文件：Detection.cs
作者：auus
邮箱：#Email#
日期：2023/03/08 17:46:45
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    private bool isMove = false;

    private Ray ray;
    private RaycastHit hit;
    public void Start()
    {
        ray = new Ray(transform.position - Vector3.up * 100, Vector3.up);
        Debug.DrawRay(ray.origin, ray.direction,Color.green, 100);
        //Debug.DrawLine(ray.origin, ray.direction, Color.green, 100);
    }

    public void Update()
    {
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.name == "Sphere")
            {
                Debug.Log(hit.collider.name);
                Time.timeScale = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Sphere")
        {
            Debug.LogError(collision.transform.name);
        }
    }
}
