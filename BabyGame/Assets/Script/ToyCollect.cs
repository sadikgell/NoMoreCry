using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCollect : MonoBehaviour
{

    public GameObject Toys;
    private GameManager gameManager;
    private Interaction interaciton;

    
    private int ToyNumber=0;

    // Start is called before the first frame update
    void Start()
    {
        interaciton = GameObject.Find("Main Camera").GetComponent<Interaction>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Toys = GameObject.Find("Toys");
    }   

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.transform.parent.name == "Toys")
        {

            if (ToyNumber == 0) 
            {
                other.gameObject.transform.position = new Vector3(14.628f, -2.188f, -16.114f);
                other.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 133.428f, 0));
                ToyNumber++;
            }
            if (ToyNumber == 1)
            {
                //toyLocation
            }
            
            



            gameManager.inCaseToy += 1;
            interaciton.InteractionClear();
            Debug.Log(gameManager.inCaseToy);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
