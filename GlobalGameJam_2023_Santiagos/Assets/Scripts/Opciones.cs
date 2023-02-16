using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour
{
    [SerializeField] private GameObject opciones,menu;
    // Start is called before the first frame update
    void Start()
    {
        opciones.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpcioneActive()
    {
        opciones.SetActive(true);
        //menu.SetActive(false);
    }
    public void Desactivar()
    {
        opciones.SetActive(false);
        //menu.SetActive(true);
    }
}
