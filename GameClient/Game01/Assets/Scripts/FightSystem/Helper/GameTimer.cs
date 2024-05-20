/**********************************************************
文件：GameTimer.cs
作者：auus
邮箱：#Email#
日期：2023/03/21 14:18:46
功能：Nothing
/**********************************************************/

using System;

/// <summary>
/// 游戏时间
/// </summary>
public class GameTimer
{
    private float _maxTime;

    private float _time;

    private Action _onFinish;

    public bool IsRunning => _time < _maxTime;

    public bool IsFinished => _time >= _maxTime;

    public float Time => _time;

    public float MaxTime
    {
        get => _maxTime;
        set => _maxTime = value;
    }

    public GameTimer(float maxTime)
    {
        if(maxTime <= 0)
        {
            throw new Exception("_maxTime can not be 0");
        }

        _maxTime = maxTime;
        _time = 0f;
    }

    public void Reset()
    {
        _time = 0f;
    }

    /// <summary>
    /// 时间结束后执行
    /// </summary>
    /// <param name="delta"></param>
    /// <param name="onFinish"></param>
    /// <returns></returns>
    public GameTimer UpdateAsFinish(float delta, Action onFinish)
    {
        if (!IsFinished)
        {
            _time += delta;
            if(onFinish != _onFinish)
            {
                _onFinish = onFinish;
            }
            if (IsFinished)
            {
                _onFinish?.Invoke();
            }
        }
        return this;
    }

    /// <summary>
    /// 时间结束后执行
    /// </summary>
    /// <param name="delta"></param>
    /// <returns></returns>
    public GameTimer UpdateAsFinish(float delta)
    {
        if (!IsFinished)
        {
            _time += delta;
            if (IsFinished)
            {
                _onFinish?.Invoke();
            }
        }
        return this;
    }

    /// <summary>
    /// 在时间间隔内重复执行
    /// </summary>
    /// <param name="delta"></param>
    /// <param name="onRepeat"></param>
    public void UpdateAsRepeat(float delta, Action onRepeat = null)
    {
        if(delta > _maxTime)
        {
            throw new Exception($"_maxTime too small, delta:{delta} > _maxTime:{_maxTime}");
        }
        _time += delta;
        if(onRepeat != _onFinish)
        {
            _onFinish = onRepeat;
        }
        while(_time >= _maxTime)
        {
            _time -= _maxTime;
            _onFinish?.Invoke();
        }
    }

    public void OnFinsih(Action onFinish)
    {
        _onFinish = onFinish;
    }

    public void OnRepeat(Action onRepeat)
    {
        _onFinish = onRepeat;
    }
}
