﻿using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class InstantiatePlayerCommand : Command
    {
        [Inject]
        public GameModel GameModel { get; set; }
        private string path = "Prefabs/Game/Player/Player";

        public override void Execute()
        {
            if(GameModel.player == null)
            {
                Object prefab = Resources.Load(path, typeof(GameObject));

                if (!prefab)
                {
                    Debug.LogError("Resources.Load  prefab == NULL");
                }
                else
                {
                    GameObject clone = GameObject.Instantiate(
                        prefab, Vector3.zero, Quaternion.Euler(0,0,180), GameModel.gameField) as GameObject;
                    clone.transform.localPosition = new Vector3(0,-350,0);
                    GameModel.player = new Player(clone.GetComponent<GameObjectView>(), 10, 500, 10000);
                }
            }
            else
            {
                GameObject clone = GameObject.Instantiate(GameModel.player.Object.gameObject,
                        Vector3.zero, Quaternion.Euler(0, 0, 180), GameModel.gameField) as GameObject;
                clone.transform.position = new Vector3(0, -350, 0);
            }
        }
    }
}