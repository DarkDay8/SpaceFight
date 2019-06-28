using strange.extensions.command.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace SpaceFightProject
{
    public class GameController
    {
        private GameModel gameModel;
        private Rigidbody rb;
        private Timer timer;

        public GameController(GameModel game)
        {
            gameModel = game;
        }

        public void StartGame()
        {
            TimerCallback tm = new TimerCallback(timer_Tick);
            timer = new Timer(timer_Tick, null, 0, 100);
        }

        private void timer_Tick(object state)
        {
            Debug.Log("Tick");
           
        }
    }
}
