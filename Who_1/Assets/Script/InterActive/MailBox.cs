using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : InterActiveBase
{
    private SpriteRenderer spriteRenderer;

    private BoxCollider2D boxCollider;

    [SerializeField]private Sprite openSprite;

    private void OnEnable()
    {
        GameEventManager.MainInstance.AddEventListening("添加场景物品数据", AfterSceneLoadedEvent);
    }

    private void OnDisable()
    {
        GameEventManager.MainInstance.RemoveEvent("添加场景物品数据", AfterSceneLoadedEvent);
    }

    private void Awake()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        boxCollider=GetComponent<BoxCollider2D>();
    }

    private void AfterSceneLoadedEvent()
    {
        if (!isDone)
        {
            transform.Find("mail_piece").gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = openSprite;
            boxCollider.enabled = false;
        }
    }

    protected override void OnClickedAction()
    {
        spriteRenderer.sprite=openSprite;
        transform.Find("mail_piece").gameObject.SetActive(true);
    }


}
