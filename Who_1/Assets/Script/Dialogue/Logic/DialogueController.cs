using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private Dialogue_Data_SO dialogueEmpty;

    [SerializeField] private Dialogue_Data_SO dialogueFinish;

    private Stack<string> dialogueEmptyStack;

    private Stack<string> dialogueFinishStack;

    private bool isTalking;

    private void Awake()
    {
        FillDialogueStack();
    }

    private void FillDialogueStack()//堆栈数据初始化
    {
        dialogueEmptyStack = new Stack<string>();//堆栈数据初始化
        dialogueFinishStack = new Stack<string>();

        for(int i= dialogueEmpty.dialogueList.Count-1; i>=0; i--)
        {
            dialogueEmptyStack.Push(dialogueEmpty.dialogueList[i]);
        }

        for(int i= dialogueFinish.dialogueList.Count-1;i>=0;i--)
        {
            dialogueFinishStack.Push(dialogueFinish.dialogueList[i]);
        }
    }


    public void ShowDialogueEmpty()//播放对话
    {
        if (!isTalking)
            StartCoroutine(DialogueRoutine(dialogueEmptyStack));
    }

    public void ShowDialogueFinish()//播放对话
    {
        if (!isTalking)
            StartCoroutine(DialogueRoutine(dialogueFinishStack));
    }

    private IEnumerator DialogueRoutine(Stack<string> data)
    {
        isTalking = true;
        if(data.TryPop(out string result))
        {
            GameEventManager.MainInstance.CallEvent("传入文本数据", result);
            yield return null;
            isTalking = false;
            GameEventManager.MainInstance.CallEvent("游戏状态", GameState.Pause);
        }
        else
        {
            GameEventManager.MainInstance.CallEvent("传入文本数据", string.Empty);
            isTalking=false;
            GameEventManager.MainInstance.CallEvent("游戏状态", GameState.GamePlay);
        }
    }
}
