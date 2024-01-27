using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCollect : MonoBehaviour
{ 
    private GameManager gameManager;
    private Interaction interaciton;
    private int ToyNumber = 0;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        interaciton = GameObject.Find("Main Camera").GetComponent<Interaction>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }   

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.transform.parent.name == "Toys")
        {

            if (ToyNumber == 0) 
            {  
                /*
                Instantiate(other.gameObject, new Vector3(14.628f, -2.188f, -16.114f), Quaternion.Euler(new Vector3(0, 133.428f, 0)));
                //other.gameObject.transform.position = new Vector3(14.628f, -2.188f, -16.114f);  
                */
                interaciton.InteractionClear();
                ToyNumber++;
                Destroy(other.gameObject);
            }
            if (ToyNumber == 1)
            {
                //toyLocation
            } 

            gameManager.inCaseToy += 1;
            Debug.Log("gameManager.inCaseToy: " + gameManager.inCaseToy);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
