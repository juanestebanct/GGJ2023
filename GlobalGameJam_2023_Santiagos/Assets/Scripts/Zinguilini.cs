using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zinguilini : MonoBehaviour
{
    [SerializeField] private Transform [] Positions;
    [SerializeField] private Rigidbody2D ZinguiliniRb;
    [SerializeField] private float Speed= 0.1f;
    [SerializeField] private Transform LastPositions;
    [SerializeField] private int Position;


    // Start is called before the first frame update
    void Start()
    {
        ZinguiliniRb = GetComponent<Rigidbody2D>();
      

    }

    // Update is called once per frame
    void Update()
    {
        if (Positions.Length> Position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Positions[Position].transform.position, Speed);
            float a = Vector3.Distance(transform.position, Positions[Position].transform.position);
            if (a==0)
            {
                Position++;
            }
        }
       
       // Debug.Log(a+"faltantes");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("coliciono");
    }
}
