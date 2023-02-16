using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screncontroller : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivefullCren(bool scren)
    {
        Screen.fullScreen = scren;
    }
}
