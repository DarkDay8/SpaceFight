using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class PlayerBulletCustomizer
    {
        private string prefabLink = "Prefabs/Game/Bullets/Bullet1";
        private GameObject prefab;
        private Transform player;

        public int HP { set; get; }
        public Vector2 Velocity { set; get; }
        public int Power { set; get; }

        public PlayerBulletCustomizer SetParameters(int hp, Vector2 velocity, int power)
        {
            HP = hp;
            Velocity = velocity;
            Power = power;
            return this;

        }
        public PlayerBulletCustomizer SetPlayer(Player player)
        {
            this.player = player.Object.transform;
            return this;
        }

        public PlayerBulletCustomizer()
        {
            LoadPrefab();
        }
        public BaseGameObject BulletSpawn( Transform gameField)
        {

            GameObject clone = GameObject.Instantiate(prefab, Vector3.zero,
                Quaternion.identity, player) as GameObject;
            clone.transform.localPosition = new Vector3(0, -30, 0); //Change position 
            clone.GetComponent<Rigidbody2D>().AddForce(Velocity);
            Debug.Log(Velocity.x + " " + Velocity.y);
            return new BaseGameObject(clone.GetComponent<GameObjectView>(),
                HP, 0, Power, Fractions.Player);
        }
        private void LoadPrefab()
        {
            prefab = Resources.Load(prefabLink, typeof(GameObject)) as GameObject;
        }
    }
}