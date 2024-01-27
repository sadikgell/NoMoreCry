using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCollect : MonoBehaviour
{ 
    private GameManager gameManager;
    private Interaction interaciton;
    private int ToyNumber = 0;
    public Vector3 offset;

    public GameObject toy1;
    public Transform toy1Area;

    public GameObject toy2;
    public Transform toy2Area;

    public GameObject toy3;
    public Transform toy3Area;

    public GameObject toy4;
    public Transform toy4Area;

    // Start is called before the first frame update
    void Start()
    {
        interaciton = GameObject.Find("Main Camera").GetComponent<Interaction>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        AreaCreator(toy1, toy1Area);
        AreaCreator(toy2, toy2Area);
        AreaCreator(toy3, toy3Area);
        AreaCreator(toy4, toy4Area);

    }   

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.transform.parent.name == "Toys")
        {

            if (ToyNumber == 0) 
            {
                ToyTP(other, toy1Area);

                interaciton.InteractionClear();
                ToyNumber++;
                
            }
            if (ToyNumber == 1)
            {
                ToyTP(other, toy2Area);
            }
            if(ToyNumber == 2)
            {
                ToyTP(other, toy3Area);
            }
            if(ToyNumber == 3)
            {
                ToyTP(other, toy4Area);
            }

            gameManager.inCaseToy += 1;
            Debug.Log("gameManager.inCaseToy: " + gameManager.inCaseToy);
        }
    }

    public void AreaCreator(GameObject toy , Transform toyArea)
    {
        toy = GameObject.Find($"{toyArea.name}");
        toyArea = toy.transform;
        toy.SetActive(false);
    }

    public void ToyTP(Collider other,Transform toyArea)
    {
        other.transform.position = toyArea.position;
        other.transform.rotation = toyArea.rotation;
        other.transform.localScale = toyArea.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
