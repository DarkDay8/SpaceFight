using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SpaceFightProject
{
    public class MainMenuView : View, IMyView
    {
        [Inject]
        public PreferencesModel PreferencesModel { get; set; }
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher dispatcher { get; set; }


        public Button start;
        public Button option;
        public Button exit;

        public Slider music;
        public Slider soundEffect;
        public Dropdown localization;
        public Button optionBack;
        public Text musicText;
        public Text effectText;
        public Animator optionPanel;

        public void LoadView()
        {
            SetBacePreferences();
            start.onClick.AddListener(StartGame);
            option.onClick.AddListener(() => { optionPanel.Play("OptionStart"); });
            optionBack.onClick.AddListener(() => { optionPanel.Play("OptionBack"); });
            exit.onClick.AddListener(() => { Application.Quit(); });
            music.onValueChanged.AddListener(ChangePreferences);
            soundEffect.onValueChanged.AddListener(ChangePreferences);
            localization.onValueChanged.AddListener(ChangeLocalizationInPreferenses);         
            ChoiceLocalization();
        }

        private void SetBacePreferences()
        {
            music.value = PreferencesModel.music;
            soundEffect.value = PreferencesModel.soundEffects;
            localization.value = localization.options.FindIndex((i) => { return i.text.Equals(PreferencesModel.localization); });
        }

        private void ChangeLocalizationInPreferenses(int index)
        {
            PreferencesModel.localization = localization.options[index].text;
            ChoiceLocalization();
        }

        private void ChangePreferences(float arg0)
        {
            PreferencesModel.music = music.value;
            PreferencesModel.soundEffects = soundEffect.value;
        }

        private void StartGame()
        {
            dispatcher.Dispatch(GlobalEvents.E_RemoveView, "MainMenu");
            dispatcher.Dispatch(GlobalEvents.E_LoadView, "MainGameField");
        }

        private void ChoiceLocalization()
        {
            switch (PreferencesModel.localization)
            {
                case "Ru":
                    {
                        SetLocalization(new MainMenuRu());
                        break;
                    }
                case "Eng":
                    {
                        SetLocalization(new MainMenuEng());
                        break;
                    }
                default:
                    {
                        SetLocalization(new MainMenuRu());
                        break;
                    }
            }
        }

        private void SetLocalization(MainMenuLocalization localization)
        {
            start.GetComponentInChildren<Text>().text = localization.startBtn;
            option.GetComponentInChildren<Text>().text = localization.optionBtn;
            exit.GetComponentInChildren<Text>().text = localization.exitBtn;
            optionBack.GetComponentInChildren<Text>().text = localization.backBtn;
            musicText.text = localization.musicText;
            effectText.text = localization.effectText;
        }

        public void RemoveView()
        {

        }
    }
}
