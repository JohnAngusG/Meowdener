using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
public class StartMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject emoji;

    public void OnPointerEnter(PointerEventData eventData) { 
        emoji.SetActive(true);
    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        emoji.SetActive(false);

    }
}
