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
    public float time, stead;
    Vector3 direction;

    private void Awake()
    {
        stead = Speed * Time.deltaTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        int ruta= Random.RandomRange(1,4);
        Positions = FindObjectOfType<GenerationZiguilini>().GetZinguiliniPosition(ruta);
        LastPositions= FindObjectOfType<GenerationZiguilini>().GetZinguiliniLastPosition(ruta-1);
        ZinguiliniRb = GetComponent<Rigidbody2D>();
        direction = transform.position - Positions[0].position;
        for(int i = 0; i < Positions.Length; i++)
        {
            Positions[i].position= (Positions[i].position + new Vector3(Random.Range(-1, 1), Random.Range(-1,1), 0));

        }
    }

    // Update is called once per frame
    void Update()
    {

        //si hay posiciones de ir va 
        if (!stop && Positions.Length!= (Position))
        {
           
           
            transform.position = Vector3.MoveTowards(transform.position, Positions[Position].position, stead);

            
            float a = Vector3.Distance(transform.position, Positions[Position].position);
            if (a==0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, stead, 0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
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
        float DistanMe, OtheListan;
        Debug.Log("coliciono");
        if (collision.gameObject.GetComponent<Zinguilini>())
        {
            Zinguilini othercollision = collision.gameObject.GetComponent<Zinguilini>();
                StartCoroutine(OtherDirecion(othercollision));
        }
    }
    public void Dead()
    {
        Debug.Log("murio");
        DOTween.Sequence()
       .Append(transform.DOScale(1.5f, 0.4f))
       .Append(transform.DOScale(0.2f, 0.1f)
       .OnComplete(() => explocion()));
    }
    public void explocion()
    {
       
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
    IEnumerator OtherDirecion(Zinguilini othercollision)
    {
   
        float DistanMe, OtheListan;
        if (!stop && Positions.Length != (Position))
        {
            direction = transform.position - Positions[Position].position;
            DistanMe = Vector3.Distance(transform.position, Positions[Position].position);
            OtheListan = Vector3.Distance(othercollision.transform.position, Positions[Position].position);
           
        }
        else
        {
            direction = transform.position - LastPositions.position;
            DistanMe = Vector3.Distance(transform.position, LastPositions.position);
            OtheListan = Vector3.Distance(othercollision.transform.position, LastPositions.position);
        }
        if (DistanMe < OtheListan)
        {
            othercollision.stead = -othercollision.stead;
            yield return new WaitForSeconds(0.1f);
            stop = true;
            yield return new WaitForSeconds(0.5f);
            stop = false;
            othercollision.stead = -othercollision.stead;
        }
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, stead, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);


    }


}
