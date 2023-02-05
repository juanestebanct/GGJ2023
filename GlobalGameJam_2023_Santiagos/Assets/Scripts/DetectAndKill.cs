using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndKill : MonoBehaviour
{
    Queue<Collider2D> queue = new Queue<Collider2D>();
    public LayerMask Enemy;
    private bool destroy =false;
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
        Debug.Log("entra a la colision");
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !destroy)
        {
            destroy = true;
           // Debug.Log("bum");
            DesTroyEnemy();
            
        }
    }
    private void DesTroyEnemy()
    {
        Collider2D [] arrayOverlap = Physics2D.OverlapCircleAll(transform.position, range, Enemy);
        List<Collider2D> list = new List<Collider2D>();
        list.AddRange(arrayOverlap);
        list.ForEach(o => queue.Enqueue(o));
        
        queue.Dequeue().GetComponent<Zinguilini>().Dead();
        
        destroy = false;
    }

}
