using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private Transform controlerShoot;
    [SerializeField] private GameObject bull;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if  (Input.GetKeyDown("space"))
        {
            Debug.Log("disparo");
            Instantiate(bull, controlerShoot.position, controlerShoot.rotation);
        }
    }
}
