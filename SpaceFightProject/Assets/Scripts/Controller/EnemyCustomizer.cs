using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceFightProject
{
    public class EnemyCustomizer
    {
        private string prefabLink = "Prefabs/Game/Enemys/Enemy";
        private GameObject prefab;

        private float minSpeed;
        private float maxSpeed;
        private int minHp;
        private int maxHp;
        public int Power { set; get; }

        public EnemyCustomizer()
        {
            SetBaseParamerers();
            LoadPrefab();
        }
        public EnemyCustomizer SetSpeed(float min, float max)
        {
            minSpeed = min;
            maxSpeed = max;
            return this;
        }
        public EnemyCustomizer SetHp(int min, int max)
        {
            minHp = min;
            maxHp = max;
            return this;
        }
        public BaseGameObject EnemySpawn(Transform spawn)
        {
            Debug.Log("Spawn!!");
            Debug.Log(spawn);
            float speed = Random.Range(minSpeed, maxSpeed);
            prefab.GetComponent<Rigidbody2D>().gravityScale = speed;
            Debug.Log("Set Speed");
            GameObject clone = GameObject.Instantiate(prefab, Vector3.zero, 
                Quaternion.identity, spawn) as GameObject;
            clone.transform.localPosition = new Vector3(0, 0, 0); //Change position 
            Debug.Log("Was Spawn");
            return new BaseGameObject(clone.GetComponent<GameObjectView>(), 
                RandomNumber(minHp, maxHp), 0, Power, Fractions.Enemy);
        }
        private int RandomNumber(int min, int max)
        {
            System.Random random = new System.Random();
            return random.Next(min, max);
        }
        private void LoadPrefab()
        {
            Debug.Log(prefab);
            prefab = Resources.Load(prefabLink, typeof(GameObject)) as GameObject;
            Debug.Log(prefab);
        }
        private void SetBaseParamerers()
        {
            minSpeed = 7;
            maxSpeed = 11;
            minHp = 4;
            maxHp = 10;
            Power = 1;
        }
    }
}
