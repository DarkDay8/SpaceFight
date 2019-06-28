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
    public class MainGameFieldView : View, IMyView
    {
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher dispatcher { get; set; }
        [Inject]
        public GameModel GameModel { get; set; }
        [Inject]
        public PreferencesModel PreferencesModel { get; set; }

        public Transform gameField;

        public void LoadView()
        {
            Debug.Log("Start Load");
            SetBacePreferences();
            GameModel.gameField = gameField;
            dispatcher.Dispatch(GlobalEvents.E_InstantiatePlayer);
            Debug.Log("End Load");
        }

        private void SetBacePreferences()
        {
          
        }
 
        public void RemoveView()
        {

        }
    }
}
