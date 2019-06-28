using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class Player : BaseGameObject
    {
        public int Score { get; set; }

        public Player() { }
        public Player(Transform obj) : base(obj) { }
        public Player(Transform obj, float maxHp) : base(obj, maxHp) { }

    }
}
