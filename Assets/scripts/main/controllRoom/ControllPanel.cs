using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace main{
    public class ControllPanel : MonoBehaviour{
        //private GameObject _all;
        private Spawn _spawn;

        public void AddEnemy(){
            //_spawn.GetComponent<Spawn>().SpawnHere(-3, 1, 5);
            Rigidbody2D enemy = gameObject.GetComponent<EnemyInstance>().CreateEnemy();
            Bounds bound = enemy.gameObject.GetComponent<Renderer>().bounds;
            float[] arr = _spawn.GetComponent<Spawn>().SpawnHere(-3, 1, bound.size.x, bound.size.y);
            enemy.transform.position = new Vector2(arr[0], arr[1]);
        }

        void Start(){
            //_all = new GameObject("controllPanelAllGO");
            _spawn = gameObject.AddComponent<Spawn>();
            gameObject.AddComponent<EnemyInstance>();
        }
    }
}