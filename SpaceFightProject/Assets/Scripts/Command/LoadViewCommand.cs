using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class LoadViewCommand : Command
    {
        [Inject]
        public IEvent eventData { get; set; }

        public override void Execute()
        {
            string nameScreen = "";
            if (eventData.data != null)
            {
                nameScreen = eventData.data.ToString();
            }
            LoadScreen(nameScreen);
        }

        private void LoadScreen(string nameScreen)
        {
            Object obj = GameObject.Find(nameScreen);
            if (!obj)
            {
                Object prefab = Resources.Load("Prefabs/UI/" + nameScreen, typeof(GameObject));
                if (!prefab)
                {
                    Debug.LogError("Resources.Load  prefab == NULL");
                    Debug.LogError("Resources name: " + nameScreen);
                }
                else
                {
                    GameObject clone = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                    clone.transform.position = Vector3.one;
                    clone.name = nameScreen;        
                }
            }           
        }
    }
}
