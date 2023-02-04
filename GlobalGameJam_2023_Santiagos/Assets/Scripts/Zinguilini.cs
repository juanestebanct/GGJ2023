using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine;
public class Zinguilini : MonoBehaviour
{
    [SerializeField] private Transform [] Positions;
    [SerializeField] private Rigidbody2D ZinguiliniRb;
    [SerializeField] private float Speed= 0.1f;
    [SerializeField] private Transform LastPositions;
    [SerializeField] private int Position;
    [SerializeField] private bool stop;
    [SerializeField] private float time, stead;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Positions = FindObjectOfType<GenerationZiguilini>().GetZinguiliniPosition();
        LastPositions= FindObjectOfType<GenerationZiguilini>().GetZinguiliniLastPosition();
        ZinguiliniRb = GetComponent<Rigidbody2D>();
        stead = Speed * Time.deltaTime;
        direction = transform.position - Positions[0].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //si hay posiciones de ir va 
        if (!stop && Positions.Length!= (Position))
        {

           
            transform.position = Vector3.MoveTowards(transform.position, Positions[Position].position, stead);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, stead, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            float a = Vector3.Distance(transform.position, Positions[Position].position);
            if (a==0)
            {
               
                Position++;
                Debug.Log(Position); 
                StartCoroutine(StopOneMoment());
                if (Positions.Length != (Position))
                {
                    direction = transform.position - Positions[Position].position;
                }
                else
                {
                    direction = transform.position - LastPositions.position;
                }
                
            }
        }
        //si ya llega a la finala
        else if (!stop && Positions.Length==(Position))
        {
            transform.position = Vector3.MoveTowards(transform.position, LastPositions.position, stead);
            float a = Vector3.Distance(transform.position, LastPositions.position);
            if (a == 0)
            {
                StartCoroutine(ChageLoop());
            }
        }
       
       // Debug.Log(a+"faltantes");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("coliciono");
    }
 
    IEnumerator StopOneMoment()
    {
        stop = true;
         Vector3 posicion = transform.position;
 
        DOTween.Sequence()
          .Append(transform.DOMove(transform.position + new Vector3(Random.Range(0.1f, 0.1f), Random.Range(0.1f, 0.1f), 0), 0.5f))
           .Append(transform.DOMove(posicion, 0.5f)) ;
           
        yield return new WaitForSeconds(time);
      
        stop = false;

    }
    IEnumerator ChageLoop()
    {
        float starSpeed = stead;
        stop = true;
        Vector3 posicion = transform.position;
        Position--;
        yield return new WaitForSeconds(time/2);

        stop = false;

    }

}
