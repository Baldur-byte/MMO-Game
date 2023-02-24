using System;
using System.IO;
using UnityEditor;

/// <summary>
/// 修改新建脚本中的指定信息
/// </summary>
public class AddScriptsInfo : UnityEditor.AssetModificationProcessor
{
    private static string fileDescribe =
        "/**********************************************************\n" +
        "文件：#SCRIPTNAME#\n" +
        "作者：#CreateAuthor#\n" +
        "邮箱：#Email#\n" +
        "日期：#CreateTime#\n" +
        "功能：Nothing\n" +
        "/**********************************************************/\n\n";

    /// <summary>
    /// 在创建资源的时候执行的函数
    /// </summary>
    /// <param name="path">脚本路径</param>
    private static void OnWillCreateAsset(string path)
    {
        //将.meta文件屏蔽，避免获取到.meta文件
        path = path.Replace(".meta", "");

        //只对.cs文件操作
        if(path.EndsWith(".cs") == true)
        {
            //文件名的分割获取
            string[] iterm = path.Split('/');

            string str = fileDescribe;

            //读取改路径该路径下的.cs文件中的所有脚本
            str += File.ReadAllText(path);

            //进行关键字文件名，作者和时间获取并替换
            str = str.Replace("#SCRIPTNAME#", iterm[iterm.Length - 1]).Replace("#CreateAuthor#", Environment.UserName).Replace("#CreateTime#", string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));

            //自动化修改脚本
            switch(iterm[iterm.Length - 2])
            {
                case "Manager":
                    str = str.Replace("MonoBehaviour", $"MonoSingleton<{iterm[iterm.Length - 1].Split(".")[0]}>");
                    break;
                case "SceneLogic":
                    str = str.Replace("MonoBehaviour", "UIScene");
                    break;
                case "WindowLogic":
                    str = str.Replace("MonoBehaviour", "UIWindow");
                    break;
            }

            //重新写入脚本
            File.WriteAllText(path, str);
        }
    }
    
    /// <summary>
    /// 在移动脚本所在文件夹时调用
    /// </summary>
    /// <param name="sourcePath"></param>
    /// <param name="destinationPath"></param>
    /// <returns></returns>
    private static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
    {
        AssetMoveResult assetMoveResult = AssetMoveResult.DidMove;

        // Perform operations on the asset and set the value of 'assetMoveResult' accordingly.

        return assetMoveResult;
    }
}
