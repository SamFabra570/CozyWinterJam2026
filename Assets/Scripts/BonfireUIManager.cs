using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonfireUIManager : MonoBehaviour
{
    public GameObject bonfireCanvas;
    public GameObject journalScreenUI;
    public GameObject returnToJourneyButton;
    
    public static BonfireUIManager Instance;

    public DraggableItem theme1;
    public DraggableItem theme2;
    public DraggableItem theme3;

    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bonfireCanvas.SetActive(false);
        journalScreenUI.SetActive(false);
    }

    public void ToggleBonfire(string status)
    {
        switch (status)
        {
            case ("Open"):
                PlayerController.Instance.freezePlayer = true;
                bonfireCanvas.SetActive(true);
                JournalManager.Instance.aboutPage.SetActive(true);
                journalScreenUI.SetActive(true);
                break;
            case ("Close"):
                PlayerController.Instance.freezePlayer = false;
                PlayerController.Instance.LockCursor();
                JournalManager.Instance.ResetEntry();
                JournalManager.Instance.currentBonfire = null;
                JournalManager.Instance.currentTheme = null;
                ResetThemePositions();
                bonfireCanvas.SetActive(false);
                break;
        }
        
    }

    private void ResetThemePositions()
    {
        theme1.ResetPosition();
        theme2.ResetPosition();
        theme3.ResetPosition();
    }

    public void ToggleJournal(string status)
    {
        switch (status)
        {
            case ("Open"):
                journalScreenUI.SetActive(true);
                returnToJourneyButton.SetActive(false);
                break;
            case ("Close"):
                journalScreenUI.SetActive(false);
                returnToJourneyButton.SetActive(true);
                break;
        }
    }
}
