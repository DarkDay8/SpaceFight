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
        //private Rigidbody rb;
        private Timer timer;
        private EnemySpawnController spawnController;

        public GameController(GameModel game)
        {
            gameModel = game;
            spawnController = new EnemySpawnController(gameModel.enemySpawnField);
            EnemySpawnController.addEnemyToList += gameModel.AddEnemy;
        }

        public void StartGame()
        {
            spawnController.StartSpawn();
        }

        private void timer_Tick(object state)
        {
            Debug.Log("Tick");
           
        }
    }
}
