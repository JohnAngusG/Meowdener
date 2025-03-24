using UnityEngine;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI moneyText;


    private void Awake()
    {
        Messenger.AddListener(GameEvent.UPDATE_MONEY, OnUpdateScore);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.UPDATE_MONEY, OnUpdateScore);
    }

    void OnUpdateScore() {
        moneyText.text = (Int32.Parse(moneyText.text) + 10).ToString();
    }



}
