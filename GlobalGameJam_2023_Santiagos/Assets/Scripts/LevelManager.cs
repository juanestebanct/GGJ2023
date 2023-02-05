using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private RootController[] level1Roots = new RootController[2];


    [SerializeField] private int currenRond;
    [SerializeField] private int[] timeRonds;
    [SerializeField] private float timeRond;

    void Start()
    {
        currenRond = 1; //inicia en ronda 1 
        timeRond = timeRonds[0];
    }

    void Update()
    {
        switch (currenRond)
        {
            case 1:
                timeRond = -Time.deltaTime;
                if (timeRond<0)
                {
                    Debug.Log("acabo la ronda");
                }
               break;
            case 2:
                break;
            case 3:
                break;

        }
    }

    public IEnumerator Level1_RootManager()
    {
        yield return null;
    }
}
