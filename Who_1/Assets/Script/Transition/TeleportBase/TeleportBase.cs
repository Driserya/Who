using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterface;

public abstract class TeleportBace : MonoBehaviour , _Click
{
    [SerializeField] private string _sceneFrom;//当前场景
    [SerializeField] private string _sceneToGo;//目标场景

    public abstract void Click();

    protected virtual void  TeleportToScene()
    {
        TransitionManager.MainInstance.Transition(_sceneFrom,_sceneToGo);
    }
}
