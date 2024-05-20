/**********************************************************
文件：UIPlayerInfo.cs
作者：auus
邮箱：#Email#
日期：2023/03/01 18:21:04
功能：Nothing
/**********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{
    [SerializeField]
    private Image headIcon;

    [SerializeField]
    private Text playerName;

    [SerializeField]
    private Slider health;

    [SerializeField]
    private Slider magic;

    public void ShowHeadIcon(Sprite sprite)
    {
        headIcon.sprite = sprite;
    }

    public void ShowName(string name)
    {
        playerName.text = name;
    }

    public void ShowHealth(float value)
    {
        health.value = value;
    }

    public void ShowMagic(float value)
    {
        magic.value = value;
    }
}
