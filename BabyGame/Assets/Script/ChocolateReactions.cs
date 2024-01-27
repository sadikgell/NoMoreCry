using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateReactions : MonoBehaviour
{
    [SerializeField] private int remaining = 3;
    [SerializeField] private GameObject chocolateItself;
    private Interaction interaction;
    public GameObject ChocolateBrocoli;
    void Start()
    {
        chocolateItself = this.gameObject;
        interaction = GameObject.Find("Main Camera").GetComponent<Interaction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractNeg"))
        {
            try
            { 
                if (other.gameObject.GetComponent<PrefabAccess>().prefabName == "Brocoli")
                { 
                    other.gameObject.tag = "InteractPos";

                    GameObject newObject = Instantiate(ChocolateBrocoli, transform.position, transform.rotation);
                     
                    Destroy(other.gameObject);

                    newObject.transform.SetParent(GameObject.Find("Food").transform,true);
                    interaction.InteractionClear();

                    remaining--;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
                throw;
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
