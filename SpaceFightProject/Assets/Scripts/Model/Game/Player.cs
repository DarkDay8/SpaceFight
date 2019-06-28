using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class Player : BaseGameObject
    {
        public int Score { get; set; }

        public Player() { }
        public Player(ref GameObject obj) : base(ref obj) { }
        public Player(ref GameObject obj, float maxHp) : base(ref obj, maxHp) { }

    }
}
