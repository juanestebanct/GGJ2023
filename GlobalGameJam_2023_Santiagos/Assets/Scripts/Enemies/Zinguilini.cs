using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Zinguilini : MonoBehaviour
{
    [SerializeField] private Transform StarPosition;
    [SerializeField] private Transform[] Positions;
    [SerializeField] private Rigidbody2D ZinguiliniRb;
    [SerializeField] private float Speed= 0.1f;
    [SerializeField] private Transform LastPositions;
    [SerializeField] private int Position;
    [SerializeField] private bool stop;
    [SerializeField] private ParticleSystem particle;
    public float time, stead;
    private Renderer render;
    bool dead=false;
    public GenerationZiguilini Generator;
    Vector3 direction;
    [SerializeField] private GameObject terrestre, volador;

    private void Awake()
    {
        System.Random random = new System.Random();
        float rnd = random.Next(0,100);
        if (rnd < 50)
        {
            terrestre.SetActive(true);
            volador.SetActive(false);
        }
        else
        {
            terrestre.SetActive(false);
            volador.SetActive(true);
        }
        
       
    }

    void Start()
    {
        render = GetComponent<Renderer>();
        int ruta= Random.Range(1,5);
        Positions = Generator.GetZinguiliniPosition(ruta);
        LastPositions= Generator.GetZinguiliniLastPosition(ruta-1);
        StarPosition= Generator.GetZinguiliniStarPosition(ruta-1);
        ZinguiliniRb = GetComponent<Rigidbody2D>();

        transform.position = StarPosition.position;
        direction = transform.position - Positions[0].position;

        if (LevelManager.Instance.CurrentLevel == 1) Speed = .9f;
        if (LevelManager.Instance.CurrentLevel == 2) Speed = .7f;
        if (LevelManager.Instance.CurrentLevel == 3) Speed = .6f;
    }
    
    void Update()
    {
        stead = Speed * Time.deltaTime;
        if (Time.timeScale == 1)
        {
            if (!stop && Positions.Length != Position)
            {         
                transform.position = Vector3.MoveTowards(transform.position, Positions[Position].position, stead); 
                float a = Vector3.Distance(transform.position, Positions[Position].position);
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, stead, 0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            
                if (Positions.Length != (Position)) direction = transform.position - Positions[Position].position;
                else direction = transform.position - LastPositions.position;
            
                if (a==0)
                {
                    Position++;
                    Debug.Log(Position); 
                    StartCoroutine(StopOneMoment());
                }
            }
            else if (!stop && Positions.Length==(Position))
            {
                transform.position = Vector3.MoveTowards(transform.position, LastPositions.position, stead);
                float a = Vector3.Distance(transform.position, LastPositions.position);
                if (a <= 0.1f)
                {
                    StartCoroutine(ChageLoop());
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Zinguilini>())
        {
            Zinguilini othercollision = collision.gameObject.GetComponent<Zinguilini>();
            StartCoroutine(OtherDirecion(othercollision));
        }
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Root") && !dead) Debug.Log("rama choco");
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAtack" && !dead)
        {
            dead = true;
            Dead();
        }
    }
    public void Dead()
    {
        dead = true;
        Debug.Log("murio");
        particle.Play();
        DOTween.Sequence()
       .Append(transform.DOScale(1.5f, 0.3f))
       .Append(transform.DOScale(0.2f, 0.1f)
       .OnComplete(() => explocion()));
    }
    public void explocion()
    {
        render.enabled = enabled;
        
        Destroy(gameObject, 0.5f);
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
        stop = true;
        Position--;
        yield return new WaitForSeconds(time/2);
        Debug.Log("GAME OVER");
        LevelManager.Instance.Lose();
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
    private void OnDisable()
    {
        DOTween.KillAll(gameObject);
    }


}
