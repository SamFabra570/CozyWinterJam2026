using System;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    public static JournalManager Instance;
    
    public GameObject currentBonfire;
    public GameObject lastBonfire;
    public GameObject currentTheme;

    public GameObject themeSlot;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    public GameObject page1Slots;
    public GameObject page2Slots;
    public GameObject page3Slots;
    
    private GameObject theme1;
    private GameObject theme2;
    private GameObject theme3;
    
    public GameObject aboutPage;
    public GameObject entryPage;
    
    public GameObject communityTheme;
    public GameObject myDayTheme;
    public GameObject myJourneyTheme;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonfire"))
        {
            currentBonfire = other.gameObject;
            Debug.Log("entered" + currentBonfire.name);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bonfire"))
        {
            if (currentBonfire != null) 
                Debug.Log("exited" + currentBonfire.name);
        
            lastBonfire = currentBonfire;
            currentBonfire = null;
            currentTheme = null;
        }
    }

    public void ShowTexts(string theme, GameObject themeText)
    {
        Debug.Log("I wish i could show texts rn, theme: " + theme);
        
        currentTheme = themeText;
        
        aboutPage.SetActive(false);
        entryPage.SetActive(true);
        
        switch (theme)
        {
            case "Community":
                communityTheme.SetActive(true);
                SetPage(currentBonfire, communityTheme);
                break;
            case "My day":
                myDayTheme.SetActive(true);
                SetPage(currentBonfire, myDayTheme);
                break;
            case "My journey":
                myJourneyTheme.SetActive(true);
                SetPage(currentBonfire, myJourneyTheme);
                break;
            
        }
    }

    private void SetPage(GameObject currentBonfire, GameObject themePage)
    {
        if (currentBonfire.name == ("Bonfire1"))
        {
            page1 = themePage;
            theme1 = currentTheme;
        }
        
        if (currentBonfire.name == ("Bonfire2"))
        {
            page2 = themePage;
            theme2 = currentTheme;
        }
        
        if (currentBonfire.name == ("Bonfire3"))
        {
            page3 = themePage;
            theme3 = currentTheme;
        }
    }

    public void ResetEntry()
    {
        if (lastBonfire.name == ("Bonfire1"))
        {
            //Debug.Log("trying to reset" + lastBonfire.name);
            page1.SetActive(false);
            theme1.SetActive(false);
            
        }
        
        if (lastBonfire.name == ("Bonfire2"))
        {
            page2.SetActive(false);
            theme2.SetActive(false);
        }
        
        if (lastBonfire.name == ("Bonfire3"))
        {
            page3.SetActive(false);
            theme3.SetActive(false);
        }
        
        if (currentTheme != null)
        {
            currentTheme.SetActive(false);
            currentTheme = null;
        }
    }
    
    public bool IsNewBonfire()
    {
        if (currentBonfire == lastBonfire)
        {
            return false;
        }

        if (lastBonfire != null)
        {
            ResetEntry();
            BonfireUIManager.Instance.ResetThemePositions();
        }
        
        return true;
    }

    public void ShowPage(int entryNum)
    {
        switch (entryNum)
        {
            case 1:
                theme1.SetActive(true);
                page1.SetActive(true);
                break;
            case 2:
                theme1.SetActive(false);
                page1.SetActive(false);
                
                theme2.SetActive(true);
                page2.SetActive(true);
                break;
            case 3:
                theme2.SetActive(false);
                page2.SetActive(false);
                
                theme3.SetActive(true);
                page3.SetActive(true);
                break;
        }
    }
}
