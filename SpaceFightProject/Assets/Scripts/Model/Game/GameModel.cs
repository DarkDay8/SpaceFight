using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class GameModel
    {
        public GameController GameController;

        public Transform gameField;
        public Player player;
        public List<BaseGameObject> enemyList;

        public int Score { get; set; }

        public void StartGame()
        {
            GameController = new GameController(this);
            GameController.StartGame();
        }
    }
}
