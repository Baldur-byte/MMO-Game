/**********************************************************
文件：RoleInfo.cs
作者：auus
邮箱：#Email#
日期：2023/02/27 11:09:57
功能：Nothing
/**********************************************************/

public class RoleInfo
{
    protected int roleId = 0;
    protected string roleName = "Unknown";
    protected string roleDescription = "nothing";
    protected int roleHealth = 100;
    protected int roleMagic = 100;
    protected int roleLevel = 0;

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

    public int Health
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

    public int Magic
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

    public int Level
    {
        get
        {
            return roleLevel;
        }
        set
        {
            roleLevel = value;
        }
    }
}
