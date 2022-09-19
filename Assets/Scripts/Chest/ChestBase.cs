using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.E;
    public Animator animator;
    public string triggerOpen = "Open";

    [Header("Notification")]
    public GameObject notification;
    public float tweenDurtation = .2f;
    public Ease ease = Ease.OutBack;
    private float startScale;

    [Space]
    public ChestItemBase chestItemBase; 


    private bool _chestOpened = false;

    void Start()
    {
        startScale = notification.transform.localScale.x;
        HideNotification();
    }

    

    [NaughtyAttributes.Button]
    private void OpenChest()
    {
        if (_chestOpened) return;
        animator.SetTrigger(triggerOpen);
        HideNotification();
        Invoke(nameof(ShowItem),1f);
    }

    private void ShowItem()
    {
        chestItemBase.ShowItem();
        Invoke(nameof(CollectItem), 1f);
    }

    private void CollectItem()
    {
        chestItemBase.Collect();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            ShowNotification();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            HideNotification();
        }
    }
    [NaughtyAttributes.Button]
    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startScale, tweenDurtation).SetEase(ease);
    }

    [NaughtyAttributes.Button]
    private void HideNotification()
    {
        notification.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && notification.activeSelf)
        {
            OpenChest();
            _chestOpened = true;
        }
    }
}
