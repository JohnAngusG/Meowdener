using UnityEngine;
using TMPro;
using System;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI moneyText;
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
        moneyText.text = (Int32.Parse(moneyText.text) + 10).ToString();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            showSettings = !showSettings;
            settingsPanel.SetActive(showSettings);
            Time.timeScale = showSettings ? 0f : 1f;
        
        }
    }

    public void OnResetButton() {
        string currScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currScene);
    
    }


}
