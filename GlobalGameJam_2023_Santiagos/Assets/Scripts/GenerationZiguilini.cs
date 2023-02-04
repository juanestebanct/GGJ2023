using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationZiguilini : MonoBehaviour
{
    [SerializeField] private Transform[] PositionsZinguilini1;
    [SerializeField] private Transform[] PositionsZinguilini2;
    [SerializeField] private Transform[] PositionsZinguilini3;
    [SerializeField] private Transform[] LastPosition;
    [SerializeField] private GameObject ziguilini;
    [SerializeField] private Transform initial;
    [SerializeField] private int allInstantes;
    public Camera camera;
    private float timeSpawn;
    public float TimeReset = 0.5f;
    private void Start()
    {
        timeSpawn = TimeReset;
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0))
        {
            if (hit.transform.tag == "EventsGame")
            {
             

            }
            
        }
        if (allInstantes>0)
        {
            timeSpawn -= Time.deltaTime;
            if (timeSpawn>0)
            {
              
            }
            else
            {
              StartCoroutine(spawn());
                timeSpawn=0.5f;
            }
          
        }
       
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
            default:
                return PositionsZinguilini1;
                break;
        }
    }
    public Transform GetZinguiliniLastPosition(int Ruta)
    {     
        return LastPosition[Ruta];
    }
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(timeSpawn );
        timeSpawn = 5;
        GameObject Zinguilini = (GameObject)Instantiate(ziguilini, initial.position, transform.rotation);
        Debug.Log("ziguilini");
        allInstantes--;
    }
  
}
