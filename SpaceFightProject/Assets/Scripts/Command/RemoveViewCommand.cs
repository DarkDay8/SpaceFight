using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class RemoveViewCommand : Command
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
            RmoveScreen(nameScreen);
        }

        private void RmoveScreen(string nameScreen)
        {
            Object obj = GameObject.Find(nameScreen);
            if (!obj)
                Debug.Log("Can't fint ogject: " + nameScreen);
            else
                GameObject.Destroy(obj);
        }
    }
}
