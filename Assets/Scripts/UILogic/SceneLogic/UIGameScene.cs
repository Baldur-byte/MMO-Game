/**********************************************************
文件：UIGameScene.cs
作者：auus
邮箱：#Email#
日期：2023/02/24 18:17:16
功能：Nothing
/**********************************************************/

using UnityEngine;
using UnityEngine.UI;

public class UIGameScene : UIScene
{
    #region 按钮
    [SerializeField]
    private Button buttonHeadIcon;

    [SerializeField]
    private Button buttonShangCheng;

    [SerializeField]
    private Button buttonHuoDong;

    [SerializeField]
    private Button buttonChouJiang;

    [SerializeField]
    private Button buttonChongZhi;

    [SerializeField]
    private Button buttonSetting;

    [SerializeField]
    private Button buttonFuBen;

    [SerializeField]
    private Button buttonBag;

    [SerializeField]
    private Button buttonGongHui;

    [SerializeField]
    private Button buttonSkill;

    [SerializeField]
    private Button buttonJingMai;

    [SerializeField]
    private Button buttonJinJie;

    [SerializeField]
    private Button buttonPaiHang;

    [SerializeField]
    private Button buttonQiangHua;

    [SerializeField]
    private Button buttonJob;

    [SerializeField]
    private Button buttonDaily;

    [SerializeField]
    private Button buttonRongLian;

    [SerializeField]
    private Button buttonEmail;

    //技能
    [SerializeField]
    private Button buttonSkill_1;

    [SerializeField]
    private Button buttonSkill_2;

    [SerializeField]
    private Button buttonSkill_3;

    [SerializeField]
    private Button buttonSkill_4;

    [SerializeField]
    private Button buttonSkill_5;

    [SerializeField]
    private Button buttonSkill_6;
    #endregion

    private GameSceneController gameSceneController;

    #region 继承方法
    protected override void OnAwake()
    {

    }

    protected override void OnStart()
    {

    }

    protected override void OnUpdate()
    {

    }

    protected override void OnFixedUpdate()
    {

    }

    public override void OnOpen()
    {

    }

    public override void OnClose()
    {

    }

    protected override void OnDestroy()
    {

    }

    public override void RegisterEvents()
    {
        buttonHeadIcon.onClick.AddListener(OnClickHeadIcon);
        buttonShangCheng.onClick.AddListener(OnClickShangCheng);
        buttonHuoDong.onClick.AddListener(OnClickHuoDong);
        buttonChouJiang.onClick.AddListener(OnClickChouJiang);
        buttonChongZhi.onClick.AddListener(OnClickChongZhi);
        buttonSetting.onClick.AddListener(OnClickSetting);
        buttonFuBen.onClick.AddListener(OnClickFuBen);
        buttonBag.onClick.AddListener(OnClickBag);
        buttonGongHui.onClick.AddListener(OnClickGongHui);
        buttonSkill.onClick.AddListener(OnClickSkill);
        buttonJingMai.onClick.AddListener(OnClickJingMai);
        buttonJinJie.onClick.AddListener(OnClickJinJie);
        buttonPaiHang.onClick.AddListener(OnClickPaiHang);
        buttonQiangHua.onClick.AddListener(OnClickQiangHua);
        buttonJob.onClick.AddListener(OnClickJob);
        buttonDaily.onClick.AddListener(OnClickDaily);
        buttonRongLian.onClick.AddListener(OnClickRongLian);
        buttonEmail.onClick.AddListener(OnClickEmail);

        //技能
        buttonSkill_1.onClick.AddListener(OnClickSkill_1);
        buttonSkill_2.onClick.AddListener(OnClickSkill_2);
        buttonSkill_3.onClick.AddListener(OnClickSkill_3);
        buttonSkill_4.onClick.AddListener(OnClickSkill_4);
        buttonSkill_5.onClick.AddListener(OnClickSkill_5);
        buttonSkill_6.onClick.AddListener(OnClickSkill_6);
    }

    public override void UnRegisterEvents()
    {
        buttonHeadIcon.onClick.RemoveListener(OnClickHeadIcon);
        buttonShangCheng.onClick.RemoveListener(OnClickShangCheng);
        buttonHuoDong.onClick.RemoveListener(OnClickHuoDong);
        buttonChouJiang.onClick.RemoveListener(OnClickChouJiang);
        buttonChongZhi.onClick.RemoveListener(OnClickChongZhi);
        buttonSetting.onClick.RemoveListener(OnClickSetting);
        buttonFuBen.onClick.RemoveListener(OnClickFuBen);
        buttonBag.onClick.RemoveListener(OnClickBag);
        buttonGongHui.onClick.RemoveListener(OnClickGongHui);
        buttonSkill.onClick.RemoveListener(OnClickSkill);
        buttonJingMai.onClick.RemoveListener(OnClickJingMai);
        buttonJinJie.onClick.RemoveListener(OnClickJinJie);
        buttonPaiHang.onClick.RemoveListener(OnClickPaiHang);
        buttonQiangHua.onClick.RemoveListener(OnClickQiangHua);
        buttonJob.onClick.RemoveListener(OnClickJob);
        buttonDaily.onClick.RemoveListener(OnClickDaily);
        buttonRongLian.onClick.RemoveListener(OnClickRongLian);
        buttonEmail.onClick.RemoveListener(OnClickEmail);

        //技能
        buttonSkill_1.onClick.RemoveListener(OnClickSkill_1);
        buttonSkill_2.onClick.RemoveListener(OnClickSkill_2);
        buttonSkill_3.onClick.RemoveListener(OnClickSkill_3);
        buttonSkill_4.onClick.RemoveListener(OnClickSkill_4);
        buttonSkill_5.onClick.RemoveListener(OnClickSkill_5);
        buttonSkill_6.onClick.RemoveListener(OnClickSkill_6);
    }
    #endregion

    #region 按钮方法
    /// <summary>
    /// 点击头像
    /// </summary>
    private void OnClickHeadIcon()
    {
        Debug.Log("点击头像");
    }

    /// <summary>
    /// 点击商城按钮
    /// </summary>
    private void OnClickShangCheng()
    {
        Debug.Log("点击商城按钮");
    }

    /// <summary>
    /// 点击活动按钮
    /// </summary>
    private void OnClickHuoDong()
    {
        Debug.Log("点击活动按钮");
    }

    /// <summary>
    /// 点击抽奖按钮
    /// </summary>
    private void OnClickChouJiang()
    {
        Debug.Log("点击抽奖按钮");
    }

    /// <summary>
    /// 点击充值按钮
    /// </summary>
    private void OnClickChongZhi()
    {
        Debug.Log("点击充值按钮");
    }

    /// <summary>
    /// 点击设置按钮
    /// </summary>
    private void OnClickSetting()
    {
        Debug.Log("点击设置按钮");
    }

    /// <summary>
    /// 点击副本按钮
    /// </summary>
    private void OnClickFuBen()
    {
        Debug.Log("点击副本按钮");
    }

    /// <summary>
    /// 点击背包按钮
    /// </summary>
    private void OnClickBag()
    {
        Debug.Log("点击背包按钮");
    }

    /// <summary>
    /// 点击公会按钮
    /// </summary>
    private void OnClickGongHui()
    {
        Debug.Log("点击公会按钮");
    }

    /// <summary>
    /// 点击技能按钮
    /// </summary>
    private void OnClickSkill()
    {
        Debug.Log("点击技能按钮");
    }

    /// <summary>
    /// 点击经脉按钮
    /// </summary>
    private void OnClickJingMai()
    {
        Debug.Log("点击经脉按钮");
    }

    /// <summary>
    /// 点击进阶按钮
    /// </summary>
    private void OnClickJinJie()
    {
        Debug.Log("点击进阶按钮");
    }

    /// <summary>
    /// 点击排行按钮
    /// </summary>
    private void OnClickPaiHang()
    {
        Debug.Log("点击排行按钮");
    }

    /// <summary>
    /// 点击强化按钮
    /// </summary>
    private void OnClickQiangHua()
    {
        Debug.Log("点击强化按钮");
    }

    /// <summary>
    /// 点击任务按钮
    /// </summary>
    private void OnClickJob()
    {
        Debug.Log("点击任务按钮");
    }

    /// <summary>
    /// 点击日常按钮
    /// </summary>
    private void OnClickDaily()
    {
        Debug.Log("点击日常按钮");
    }

    /// <summary>
    /// 点击熔炼按钮
    /// </summary>
    private void OnClickRongLian()
    {
        Debug.Log("点击熔炼按钮");
    }

    /// <summary>
    /// 点击邮件按钮
    /// </summary>
    private void OnClickEmail()
    {
        Debug.Log("点击邮件按钮");
    }

    #region 技能按钮
    private void OnClickSkill_1()
    {
        Debug.Log("技能一");
    }

    private void OnClickSkill_2()
    {
        Debug.Log("技能二");
    }

    private void OnClickSkill_3()
    {
        Debug.Log("技能三");
    }

    private void OnClickSkill_4()
    {
        Debug.Log("技能四");
    }

    private void OnClickSkill_5()
    {
        Debug.Log("技能五");
    }

    private void OnClickSkill_6()
    {
        Debug.Log("技能六");
    }
    #endregion
    #endregion
}
