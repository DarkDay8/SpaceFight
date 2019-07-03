using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class GameModel
    {
        public GameController GameController;

        public Transform gameField;
        public Transform enemySpawnField;
        public Player player;
        public List<BaseGameObject> enemyList;

        public int TotalScore { get; set; }

        public void StartGame()
        {
            enemyList = new List<BaseGameObject>();
            GameController = new GameController(this);
            GameController.StartGame();
        }
        public void AddEnemy(BaseGameObject enemy)
        {
            enemyList.Add(enemy);
        }
        public void RemoveEnemy(BaseGameObject enemy)
        {
            enemyList.Remove(enemy);
        }
    }
}
