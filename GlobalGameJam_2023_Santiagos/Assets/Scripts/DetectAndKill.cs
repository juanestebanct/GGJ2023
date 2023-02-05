using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndKill : MonoBehaviour
{

    public GameObject Object;
   
    // Start is called before the first frame update
    void Start()
    {
        Object.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(Activation());
        }
    }
    IEnumerator Activation()
    {
        
        Object.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        Object.SetActive(false);
    }
    private void DesTroyEnemy()
    {

    }

}