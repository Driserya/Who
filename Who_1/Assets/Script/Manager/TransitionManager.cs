using System;
using System.Collections;
using System.Collections.Generic;
using GGG.Tool.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{

    [SerializeField] private string startScene;

    private bool _isFade;//是否切换
    [SerializeField] private CanvasGroup _fadeCanvasGroup;//遮罩
    [SerializeField] private float fadeTime;//遮罩时间

    private void Start()
    {
        StartCoroutine(TransitionToScene(string.Empty, startScene));
    }
    public void Transition(string from,string to)
    {
        if (_isFade)
            return;
        StartCoroutine(TransitionToScene(from, to));//携程执行
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1);
        if (from != string.Empty)
        {
            GameEventManager.MainInstance.CallEvent("场景物品数据存储");
            yield return SceneManager.UnloadSceneAsync(from);//场景的卸载和加载，异步模式
        }
        yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);//添加场景模式

        //设置新场景为激活状态
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);//获取当前新场景
        SceneManager.SetActiveScene(newScene);//将新场景设置为启动
        GameEventManager.MainInstance.CallEvent("添加场景物品数据");
        yield return Fade(0);
    }


    /// <summary>
    /// 场景淡入淡出
    /// </summary>
    /// <param name="targetAlpha"></param>
    /// <returns></returns>
    private IEnumerator Fade(float targetAlpha)
    {
        _isFade = true;

        _fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(_fadeCanvasGroup.alpha - targetAlpha) / fadeTime;

        while (!Mathf.Approximately(_fadeCanvasGroup.alpha, targetAlpha))
        {
            _fadeCanvasGroup.alpha = Mathf.MoveTowards(_fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        _fadeCanvasGroup.blocksRaycasts = false;

        _isFade = false;
    }
}
