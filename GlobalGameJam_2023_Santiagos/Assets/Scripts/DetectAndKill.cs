using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndKill : MonoBehaviour
{
    Collider2D [] arrayOverlap;
    public LayerMask Enemy;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void OnDrawGizmosSelected()
    {
        

        Gizmos.DrawSphere(transform.position, range);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player"&& Input.GetKeyDown("space"))
        {
            Debug.Log("bum");
            DesTroyEnemy();
        }
    }
    private void DesTroyEnemy()
    {

        arrayOverlap = Physics2D.OverlapCircleAll(transform.position, range, Enemy);
        foreach (Collider2D col in arrayOverlap)
        {
            col.gameObject.GetComponent<Zinguilini>().Dead();
            Debug.Log(col.name);
        }
    }

}
