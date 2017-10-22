using System.Text.RegularExpressions;
using UnityEngine;

namespace main{
    public class Enemy : MonoBehaviour{
        Regex bulletMatch = new Regex("bullet");
        private int lifeCount = 3;
        
        public void OnCollisionEnter2D(Collision2D collision){
            Debug.Log("collision");
        }

        public void OnTriggerEnter2D(Collider2D other){
            if (bulletMatch.Match(other.gameObject.name).Length > 0){
                Destroy(other.gameObject);
                lifeCount--;
                if (lifeCount <= 0){
                    Destroy(gameObject);
                }
                Debug.Log("life remaining - " + lifeCount);
            }
        }
    }
}