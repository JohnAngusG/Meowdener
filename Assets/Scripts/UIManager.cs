using UnityEngine;
using TMPro;
using System;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;
using System.Collections;
public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI moneyText;
    private int score = 0;
    [SerializeField] GameObject settingsPanel;
    bool showSettings = false;

    [SerializeField] private GameObject tutorial;


    private void Start()
    {
        settingsPanel.SetActive(showSettings);
        Time.timeScale = 1f;
        StartCoroutine(DisableTutorial());
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
        
        if (score >= 100) {
            Messenger.Broadcast(GameEvent.GAME_OVER);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            showSettings = !showSettings;
            settingsPanel.SetActive(showSettings);
            Time.timeScale = showSettings ? 0f : 1f;
        
        }
    }

    private IEnumerator DisableTutorial() {
        yield return new WaitForSeconds(3);
        tutorial.SetActive(false);
    }


}
