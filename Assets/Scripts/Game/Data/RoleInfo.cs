/**********************************************************
文件：RoleInfo.cs
作者：auus
邮箱：#Email#
日期：2023/02/27 11:09:57
功能：Nothing
/**********************************************************/

using UnityEngine;

public class RoleInfo
{
    protected int roleId = 0;
    protected string roleName = "Unknown";
    protected string roleDescription = "nothing";
    protected int roleHealth = 100;
    protected int roleMagic = 100;
    protected int curHealth = 100;
    protected int curMagic = 100;
    protected int curLevel = 0;
    private Vector3 bornPos;

    public string Name
    {
        get
        {
            return roleName;
        }
        set
        {
            roleName = value;
        }
    }

    public int ID
    {
        get
        {
            return roleId;
        }
        set
        {
            roleId = value;
        }
    }

    public string Description
    {
        get
        {
            return roleDescription;
        }
        set
        {
            roleDescription = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return roleHealth;
        }
        set
        {
            roleHealth = value;
        }
    }

    public int MaxMagic
    {
        get
        {
            return roleMagic;
        }
        set
        {
            roleMagic = value;
        }
    }

    public int CurHealth
    {
        get
        {
            return curHealth;
        }
        set
        {
            curHealth = value;
        }
    }

    public int CurMagic
    {
        get
        {
            return curMagic;
        }
        set
        {
            curMagic = value;
        }
    }

    public int CurLevel
    {
        get
        {
            return curLevel;
        }
        set
        {
            curLevel = value;
        }
    }

    public Vector3 BornPos
    {
        get
        {
            return bornPos;
        }
        set
        {
            bornPos = value;
        }
    }
}
