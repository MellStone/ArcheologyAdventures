using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Material deathMaterial;
    private Renderer renderer;
    public int hp = 100;
    public int damage = 50;
    private void Start()
    {
       renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }
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
    private void Die()
    {
        renderer.material = deathMaterial;
        StartCoroutine(WaitUnilDie());
    }
    IEnumerator WaitUnilDie()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
