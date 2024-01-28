using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateReactions : MonoBehaviour
{
    [SerializeField] private int remaining = 3;
    [SerializeField] private GameObject chocolateItself;
    private Interaction interaction;
    public GameObject ChocolateBrocoli;
    public Transform chocolateBrocoliPos;

    void Start()
    {
        chocolateItself = this.gameObject;
        interaction = GameObject.Find("Main Camera").GetComponent<Interaction>();
        chocolateBrocoliPos = GameObject.Find("ChocolateBrocoliPos").GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractNeg"))
        {
           
                if (other.gameObject.GetComponent<PrefabAccess>().prefabName == "Brocoli")
                {
                    Destroy(other.gameObject);

                    GameObject newObject = Instantiate(ChocolateBrocoli, chocolateBrocoliPos.position, Quaternion.identity);
                    Debug.Log(newObject.transform);
                    

                    newObject.transform.SetParent(GameObject.Find("Food").transform,true);
                    interaction.InteractionClear();

                    remaining--;
                }
            
            
        }
    } 

    void FixedUpdate()
    {
        if (remaining <= 0)
        {
            Destroy(chocolateItself); 
        }
    }
}
