using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationZiguilini : MonoBehaviour
{
    [SerializeField] private Transform[] PositionsZinguilini1;
    [SerializeField] private Transform[] PositionsZinguilini2;
    [SerializeField] private Transform[] PositionsZinguilini3;
    [SerializeField] private Transform LastPosition;
    [SerializeField] private GameObject ziguilini;
    [SerializeField] private Transform initial;
    [SerializeField] private int allInstantes;
    
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (allInstantes>1)
        {
            GameObject Zinguilini = (GameObject)Instantiate(ziguilini, initial.position, transform.rotation);
            Debug.Log("ziguilini");
            allInstantes--;
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
            default:
                return PositionsZinguilini1;
                break;
        }

    }

    public Transform GetZinguiliniLastPosition()

    {
        
        return LastPosition;
    }
}
