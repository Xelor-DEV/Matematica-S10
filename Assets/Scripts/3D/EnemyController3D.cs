using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController3D : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            GameManagerController.Instance.UpdateEnemiesEliminated();
        }
    }
}
