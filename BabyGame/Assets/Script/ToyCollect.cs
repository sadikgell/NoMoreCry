using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ToyCollect : MonoBehaviour
{ 
    private GameManager gameManager;
    private Interaction interaciton;
    private int ToyNumber = 1;

    public GameObject toy1;
    public Transform toy1Area;

    public GameObject toy2;
    public Transform toy2Area;

    public GameObject toy3;
    public Transform toy3Area;

    public GameObject toy4;
    public Transform toy4Area;

    public GameObject toy5;
    public Transform toy5Area;

    public GameObject toy6;
    public Transform toy6Area;

    public GameObject toy7;
    public Transform toy7Area;

    public GameObject toy8;
    public Transform toy8Area;


    // Start is called before the first frame update
    void Start()
    {
        interaciton = GameObject.Find("Main Camera").GetComponent<Interaction>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        toy1Area = AreaCreator(toy1,"Toy1Area");
        toy2Area = AreaCreator(toy2, "Toy2Area");
        toy3Area = AreaCreator(toy3, "Toy3Area");
        toy4Area = AreaCreator(toy4, "Toy4Area");
        toy5Area = AreaCreator(toy5, "Toy5Area");
        toy6Area = AreaCreator(toy6, "Toy6Area");
        toy7Area = AreaCreator(toy7, "Toy7Area");
        toy8Area = AreaCreator(toy8, "Toy8Area");
        Debug.Log(toy1Area);
    }   

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.transform.parent.name == "Toys")
        {

            switch  (ToyNumber)
            {
                case 1:
                    ToyTP(other, toy1Area);

                    interaciton.InteractionClear();
                    ToyNumber++;
                    break;
                case 2:
                    ToyTP(other, toy2Area);

                    interaciton.InteractionClear();
                    ToyNumber++;
                    break;
                case 3:
                    ToyTP(other, toy3Area);

                    interaciton.InteractionClear();
                    ToyNumber++;
                    break;
                case 4:
                    ToyTP(other, toy4Area);

                    interaciton.InteractionClear();
                    ToyNumber++;
                    break;
                case 5:
                    ToyTP(other, toy5Area);

                    interaciton.InteractionClear();
                    ToyNumber++;
                    break;
                case 6:
                    ToyTP(other, toy6Area);

                    interaciton.InteractionClear();
                    ToyNumber++;
                    break;
                case 7:
                    ToyTP(other, toy7Area);

                    interaciton.InteractionClear();
                    ToyNumber++;
                    break;
                case 8:
                    ToyTP(other, toy8Area);

                    interaciton.InteractionClear();
                    ToyNumber++;
                    break;

            }

            gameManager.inCaseToy += 1;
            Debug.Log("gameManager.inCaseToy: " + gameManager.inCaseToy);
        }
    }

    public Transform AreaCreator(GameObject toy,string toyAreaName)
    {
        
        toy = GameObject.Find(toyAreaName);
        toy.SetActive(false);

        return toy.transform;
        
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
