using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndKill : MonoBehaviour
{
    public Collider2D[] arrayOverlap;
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
        arrayOverlap = Physics2D.OverlapCircleAll(transform.position, range, Enemy);
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown("space"))
        {
            foreach (Collider2D col in arrayOverlap)
            {
                col.gameObject.GetComponent<Zinguilini>().Dead();
             
            }
        }
    }
    private void DesTroyEnemy()
    {

    }

}