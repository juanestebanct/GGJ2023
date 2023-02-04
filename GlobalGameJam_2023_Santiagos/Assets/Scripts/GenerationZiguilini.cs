using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationZiguilini : MonoBehaviour
{
    [SerializeField] private Transform[] PositionsZinguilini;
    [SerializeField] private Transform LastPosition;
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

    }
    public Transform[] GetZinguiliniPosition()

    {
        return PositionsZinguilini;
    }

    public Transform GetZinguiliniLastPosition()

    {
        return LastPosition;
    }
}
