using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class Player : BaseGameObject
    {
        private PlayerMoveController moveController;

        public Player(GameObjectView obj) : base(obj) { }
        public Player(GameObjectView obj, float maxHp) : base(obj, maxHp) { }
        public Player(GameObjectView obj, float maxHp, float speed) : base(obj, maxHp, speed) { }
        public Player(GameObjectView obj, float maxHp, float speed, float pover) 
            : base(obj, maxHp, speed, pover) { }

        public Player SetMoveController()
        {
            moveController = Object.gameObject.AddComponent<PlayerMoveController>();
            moveController.speed = Speed;
            return this;
        }

    }
}
