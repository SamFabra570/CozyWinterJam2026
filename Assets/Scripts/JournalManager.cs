using System;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    public static JournalManager Instance;
    
    public GameObject currentBonfire;
    public GameObject currentTheme;

    public GameObject themeSlot;

    private GameObject page1;
    private GameObject page2;
    private GameObject page3;
    
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
        currentBonfire = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        currentBonfire = null;
        currentTheme = null;
    }

    public void ShowTexts(string theme, GameObject themeText)
    {
        Debug.Log("I wish i could show texts rn, theme: " + theme);
        
        currentTheme = themeText;
        
        aboutPage.SetActive(false);
        entryPage.SetActive(true);
        
        //themeText.SetActive(true);
        
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
        currentTheme.SetActive(false);
        currentTheme = null;
        
        if (currentBonfire.name == ("Bonfire1"))
        {
            page1.SetActive(false);
            //theme1 = currentTheme;
        }
        
        if (currentBonfire.name == ("Bonfire2"))
        {
            page2.SetActive(false);
            //theme2 = currentTheme;
        }
        
        if (currentBonfire.name == ("Bonfire3"))
        {
            page3.SetActive(false);
            //theme3 = currentTheme;
        }
    }
}
