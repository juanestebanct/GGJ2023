using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GenerationZiguilini : MonoBehaviour
{
    [SerializeField] private Transform[] PositionsZinguilini1;
    [SerializeField] private Transform[] PositionsZinguilini2;
    [SerializeField] private Transform[] PositionsZinguilini3;
    [SerializeField] private Transform[] PositionsZinguilini4;
    [SerializeField] private Transform[] PositionsStar;
    [SerializeField] private Transform[] LastPosition;
    [SerializeField] private GameObject ziguilini;
    [SerializeField] private Transform initial;
    [SerializeField] private int allInstantes;
    public bool endRonds=false;
    public int[] round;
    private float timeSpawn;
    public float TimeReset = 0.5f;
    private void Start()
    {
        timeSpawn = TimeReset;
    }
    void Update()
    {
        //si es verdadero deja de aparecer enemigos 
        if (!endRonds)
        {

            if (allInstantes > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn > 0)
                {
                  
                }
                else
                {
                    StartCoroutine(spawn());
                    timeSpawn = 0.5f;
                }

            }
           
        }
       
    }

    IEnumerator Restreappearance()
    {
        yield return new WaitForSeconds(Random.Range(20, 30));
        Debug.Log("amenaza re creada ");
        allInstantes = 20;
    }
    public Transform[] GetZinguiliniPosition(int Ruta)
    {
        switch (Ruta)
        {
            case 1:
                return PositionsZinguilini1;
                break;
            case 2:
                return PositionsZinguilini2;
                break;
            case 3:
                return PositionsZinguilini3;
                break;
            case 4:
                return PositionsZinguilini4;
            default:
                return PositionsZinguilini1;
                break;
        }
    }
    public Transform GetZinguiliniLastPosition(int Ruta)
    {     
        return LastPosition[Ruta];

    }
    public Transform GetZinguiliniStarPosition(int Ruta)
    {
        return PositionsStar[Ruta];

    }
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(timeSpawn);
        timeSpawn = 5;
        GameObject Zinguilini = (GameObject)Instantiate(ziguilini, initial.position, transform.rotation);
        Debug.Log("ziguilini");
        allInstantes--;
        if (allInstantes==0)
        {
            Debug.Log("Re creando las amenzas ");
            StartCoroutine(Restreappearance());
        }
    }
  
}
