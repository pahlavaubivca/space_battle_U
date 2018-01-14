using System.Text.RegularExpressions;
using UnityEngine;

namespace main{
    public class EnemyCollideTrigger : MonoBehaviour{
        Regex bulletMatch = new Regex("bullet");
        Regex bulletEnemyNameMatch = new Regex("enemy");
//        private int lifeCount = 3;

        public void OnCollisionEnter2D(Collision2D collision){
            // Debug.Log("collision");
        }

        public void OnTriggerEnter2D(Collider2D other){
            if (bulletMatch.Match(other.gameObject.name).Length > 0){
                //var asd = other.gameObject.GetComponent<UnityBulletInstance>();
                if (bulletEnemyNameMatch.Match(other.gameObject.name).Length <= 0){
//                    lifeCount--;
//                    if (lifeCount <= 0){
//                        gameObject.GetComponent<Fire>().ClearAll();
//                        Destroy(gameObject);
//                    }
//                    // Debug.Log("life remaining - " + lifeCount);
//                    Destroy(other.gameObject);
                }
            }
        }
    }
}