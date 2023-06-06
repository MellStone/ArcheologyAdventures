using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public int hp = 100;
    public int damage = 50;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.tag == "Arrow")
            {
                hp -= damage;          
            }
        }
    }
}
