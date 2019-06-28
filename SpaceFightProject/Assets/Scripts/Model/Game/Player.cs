using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class Player : BaseGameObject
    {
        public int Score { get; set; }
        private PlayerMoveController moveController;

        public Player() { }
        public Player(Transform obj) : base(obj) { }
        public Player(Transform obj, float maxHp) : base(obj, maxHp) { }
        public Player(Transform obj, float maxHp, float speed) : base(obj, maxHp, speed) { }

        public Player SetMoveController()
        {
            moveController = Object.gameObject.AddComponent<PlayerMoveController>();
            moveController.speed = Speed;
            return this;
        }

    }
}
