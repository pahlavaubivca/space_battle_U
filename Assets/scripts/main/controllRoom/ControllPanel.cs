using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace main{
    public class ControllPanel : MonoBehaviour{
        //private GameObject _all;
        private Spawn _spawn;

        public void AddEnemy(){
            Rigidbody2D enemy = gameObject.GetComponent<EnemyInstance>().CreateEnemy(-3, 1);
        }

        void Start(){
            //_all = new GameObject("controllPanelAllGO");
            //_spawn = gameObject.AddComponent<Spawn>();
            gameObject.AddComponent<EnemyInstance>();
        }

        void Update(){
            if (Input.GetKeyDown(KeyCode.E)){
                AddEnemy();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                // for shuttle simple bullet
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)){
                // for shuttle shutgun bullet
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)){
                // for shuttle simple laser
            }
            if (Input.GetKeyDown(KeyCode.Alpha4)){
                // for shuttle simple rocket
            }
        }
    }
}