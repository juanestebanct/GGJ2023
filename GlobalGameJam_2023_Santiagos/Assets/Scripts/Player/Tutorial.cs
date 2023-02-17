using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject z,controlers,attack;
    bool clicks,tutorialpart1, tutorialpart2, tutorialpart3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stars());
        z.SetActive(false);
        attack.SetActive(false);
        controlers.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
   
        if (tutorialpart1 && Input.GetKeyDown(KeyCode.Z))
        {
            tutorialpart2 = true;
            z.SetActive(false);
            StartCoroutine(Controllers());
        }

        if (tutorialpart2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) 
                                                  || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                controlers.SetActive(false);
                tutorialpart2 = false;
                StartCoroutine(Atack());
            }
        }
        
        if (tutorialpart3 && Input.GetKeyDown(KeyCode.X) )
        {
            StartCoroutine(HideTutorial());
        }
    }
    private IEnumerator Stars()
    {
        Debug.Log("metete a la raiz ");
        yield return new WaitForSeconds(2f);
        z.SetActive(true);

        tutorialpart1 = true;
    }
    private IEnumerator Controllers()
    {
        Debug.Log("preciona las teclas ");
        yield return new WaitForSeconds(1f);
        controlers.SetActive(true);
        tutorialpart1 = false;
    }
    private IEnumerator Atack()
    {
        Debug.Log("ataque ");
        yield return new WaitForSeconds(1f);
        attack.SetActive(true);
        tutorialpart3 = true;
    }
    public void click()
    {
        if (tutorialpart1)
        {
            Debug.Log("actio por click");
            tutorialpart2 = true;
            z.SetActive(false);
            StartCoroutine(Controllers());
        }
    }

    private IEnumerator HideTutorial()
    {
        tutorialpart2 = false;
        yield return new WaitForSeconds(2f);
        attack.SetActive(false);
        Destroy(gameObject);
    }
}
