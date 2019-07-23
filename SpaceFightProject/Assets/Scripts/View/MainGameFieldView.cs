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

        [SerializeField]
        private Transform gameField;
        [SerializeField]
        private Transform enemySpawn;
        [SerializeField]
        private GameGUIView gui;

        public GameGUIView GUI { get { return gui; } }

        public void LoadView()
        {
            GameModel.gameField = gameField;
            GameModel.enemySpawnField = enemySpawn;
         
            dispatcher.Dispatch(GlobalEvents.E_InstantiatePlayer);
            SetBacePreferences();
            dispatcher.Dispatch(GlobalEvents.E_StartGame);

        }

        private void SetBacePreferences()
        {
            gui.SetBacePreferences(GameModel);
        }
 
        public void RemoveView()
        {

        }
    }
}
