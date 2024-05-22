using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private EnemyController enemy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            enemy.DestroyThis();
            GameManagerController.Instance.UpdateEnemiesEliminated();
        }
    }
}
