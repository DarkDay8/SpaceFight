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
        public Transform enemySpawn;

        public void LoadView()
        {
            SetBacePreferences();
            GameModel.gameField = gameField;
            GameModel.enemySpawnField = enemySpawn;
         
            dispatcher.Dispatch(GlobalEvents.E_InstantiatePlayer);
            dispatcher.Dispatch(GlobalEvents.E_StartGame);
        }

        private void SetBacePreferences()
        {
          
        }
 
        public void RemoveView()
        {

        }
    }
}
