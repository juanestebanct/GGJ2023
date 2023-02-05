using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
 
    [SerializeField] private int currenRond;
    [SerializeField] private int[] timeRonds;
    [SerializeField] private float timeRond;
    // Start is called before the first frame update
    void Start()
    {
        currenRond = 1; //inicia en ronda 1 
        timeRond = timeRonds[0];
    }

    // Update is called once per frame
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
}
