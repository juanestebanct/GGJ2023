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
    [SerializeField] public int EnemyInstances;
    public bool CanSpawn;
    private float timeSpawn;
    public float TimeReset = 0.5f;
    private void Start()
    {
        CanSpawn = false;
        timeSpawn = TimeReset;
        //StartCoroutine(Restreappearance());
    }
    void Update()
    {
        //si es falso dejan de aparecer enemigos 
        if (CanSpawn)
        {
            if (EnemyInstances > 0)
            {
                timeSpawn -= Time.deltaTime;
                if (timeSpawn <= 0)
                {
                    StartCoroutine(spawn());
                    timeSpawn = 1;
                }
            }
        }
    }

    IEnumerator Restreappearance()
    {
        yield return new WaitForSeconds(Random.Range(20, 30));
        Debug.Log("amenaza re creada ");
        EnemyInstances = 20;
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
        GameObject Zinguilinii = (GameObject)Instantiate(ziguilini, initial.position, transform.rotation);
        Zinguilinii.GetComponent<Zinguilini>().Generator=this;
        EnemyInstances--;
    }
  
}
