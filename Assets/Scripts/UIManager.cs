using UnityEngine;
using TMPro;
using System;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI moneyText;
    private int score = 0;
    [SerializeField] GameObject settingsPanel;
    bool showSettings = false;


    private void Start()
    {
        settingsPanel.SetActive(showSettings);
        Time.timeScale = 1f;
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.UPDATE_MONEY, OnUpdateScore);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.UPDATE_MONEY, OnUpdateScore);
    }

    void OnUpdateScore() {
        score += 10;
        moneyText.text = score.ToString();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            showSettings = !showSettings;
            settingsPanel.SetActive(showSettings);
            Time.timeScale = showSettings ? 0f : 1f;
        
        }
    }
    



}
