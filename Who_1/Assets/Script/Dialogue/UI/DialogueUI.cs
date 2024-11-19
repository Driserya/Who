using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]private GameObject panel;

    [SerializeField]private TextMeshProUGUI dailogueText;

    private void OnEnable()
    {
        GameEventManager.MainInstance.AddEventListening<string>("传入文本数据", ShowDialogue);
    }

    private void OnDisable()
    {
        GameEventManager.MainInstance.RemoveEvent<string>("传入文本数据", ShowDialogue);
    }

    private void ShowDialogue(string dialogue)
    {
        if (dialogue != string.Empty)
            panel.SetActive(true);
        else
            panel.SetActive(false);
        dailogueText.text = dialogue;
    }
}
