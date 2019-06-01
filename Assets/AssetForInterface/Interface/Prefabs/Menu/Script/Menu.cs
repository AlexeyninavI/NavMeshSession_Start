﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : UIScreen
{
    public GameObject LanguagePanel;
    public GameObject Cursor;

    protected DataManager dm;

    public override void Show()
    {
        base.Show();
        LanguagePanel.SetActive(false);
        Cursor.GetComponent<Animation>().Play();
        Initialize();

        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            if (text.name == "TapScreenPanelRecordText")
                text.text = "" + dm.record;
        }

        if(dm.language == "rus")
        {
            ChangeRusLanguage();
            return;
        }
        if(dm.language == "eng")
        {
            ChangeEngLanguage();
            return;
        }
    }

    public void OnLanguageBtn() {
        LanguagePanel.SetActive(!LanguagePanel.activeSelf);
    }

    public void OnRusBtn() {
        dm.language = "rus";
        ChangeRusLanguage();
    }
    public void OnEngBtn() {
        dm.language = "eng";
        ChangeEngLanguage();
    }
    public void OnArrowDownBtn() {
        LanguagePanel.SetActive(!LanguagePanel.activeSelf);
    }
        
    public void OnShopBtn()
    {
        UIHome.instance.ShowShop();
        Debug.Log("Show shop!");
    }

    public void OnAboutBtn()
    {
        UIHome.instance.ShowAbout();
        Debug.Log("Show about!");
    }
    public void TapOnScreenPanel() {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Game start!");
    }
    public void Initialize()
    {
        dm = FindObjectOfType<DataManager>();
        if (dm == null)
            Debug.Log("DataManager not found!");
    }
    public void ChangeRusLanguage()
    {
        Debug.Log("Changed rus language");
        Text[] texts = GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            if (text.name == "TitlePanelBannerText") {
                text.text = "здесь могла бы быть ваша реклама"; continue;
            }
            if (text.name == "TapScreenPanelTitleRecordText") { 
                text.text = "рекорд"; continue;
            }
            if (text.name == "TapScreenPanelText") { 
                text.text = "нажмите на экран, чтобы начать играть"; continue;
            }
            if (text.name == "LanguageBtnText") { 
                text.text = "язык"; continue;
            }
            if (text.name == "ShopBtnText") { 
                text.text = "магазин"; continue;
            }
            if (text.name == "AboutBtnText") { 
                text.text = "информация"; continue;
            }  
        }
    }
    public void ChangeEngLanguage()
    {
        Debug.Log("Changed eng language");
        Text[] texts = GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            if (text.name == "TitlePanelBannerText") {
                text.text = "your advertisement could be here"; continue;
            }
            if (text.name == "TapScreenPanelTitleRecordText") { 
                text.text = "record"; continue;
            }
            if (text.name == "TapScreenPanelText") { 
                text.text = "tap the screen to start play"; continue;
            }
            if (text.name == "LanguageBtnText") { 
                text.text = "language"; continue;
            }
            if (text.name == "ShopBtnText") { 
                text.text = "shop"; continue;
            }
            if (text.name == "AboutBtnText") { 
                text.text = "about"; continue;
            }  
        }
    }
}
