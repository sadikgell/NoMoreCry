using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCollect : MonoBehaviour
{

    public GameObject Toys;
    private GameManager gameManager;

    private Interaction interaciton;

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
            Destroy(other.gameObject);
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
