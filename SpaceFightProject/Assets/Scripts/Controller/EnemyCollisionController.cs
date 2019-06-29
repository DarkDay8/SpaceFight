using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class EnemyCollisionController : MonoBehaviour
    {
        private GameObjectView GameObjectView;
        public float damage = 10;

        private void Start()
        {
            GameObjectView = gameObject.GetComponent<GameObjectView>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObjectView go = collision.GetComponent<GameObjectView>();
            go.SetDamage(GameObjectView.damagePover());
            GameObjectView.SetDamage(go.damagePover());
        }
    }
}
