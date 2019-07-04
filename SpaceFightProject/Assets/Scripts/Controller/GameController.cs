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
        private PlayerBulletCustomizer playerbulletCustomizer;

        public GameController(GameModel game)
        {
            gameModel = game;
            gameModel.player.shot += PlayerShot;
            spawnController = new EnemySpawnController(gameModel.enemySpawnField);
            EnemySpawnController.addEnemyToList += gameModel.AddEnemy;
        }

        public void StartGame()
        {
            spawnController.StartSpawn();
            playerbulletCustomizer = new PlayerBulletCustomizer();
            playerbulletCustomizer.SetParameters(1, new Vector2(0, 4), 5).SetPlayer(gameModel.player);
        }
        public void PlayerShot()
        {
            playerbulletCustomizer.BulletSpawn(gameModel.gameField);
        }
    }
}
