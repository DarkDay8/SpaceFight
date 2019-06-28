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
        [Inject]
        public PreferencesModel PreferencesModel { get; set; }
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher dispatcher { get; set; }

        public void LoadView()
        {
            SetBacePreferences();
      
        }

        private void SetBacePreferences()
        {
          
        }
 
        public void RemoveView()
        {

        }
    }
}
