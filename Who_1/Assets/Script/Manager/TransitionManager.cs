using System.Collections;
using System.Collections.Generic;
using GGG.Tool.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public void Transition(string from,string to)
    {
        StartCoroutine(TransitionToScene(from, to));//携程执行
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return SceneManager.UnloadSceneAsync(from);//场景的卸载和加载，异步模式
        yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);//添加场景模式

        //设置新场景为激活状态
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);//获取当前新场景
        SceneManager.SetActiveScene(newScene);//将新场景设置为启动
    }
}
