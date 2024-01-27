using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyAnimationStates : MonoBehaviour
{
    //idle laugh bore and sleep animation control 
    private Animator anim; 
    private Happiness happiness;
    private enum AnimationState { idle, laughing, bored, sleeping }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        happiness = GameObject.Find("GameManager").GetComponent<Happiness>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAnimationState();
    } 

    private void UpdateAnimationState()
    {
        AnimationState state;

        state = AnimationState.idle;

        if (happiness.getHappiness() >= 70)
        {
            state = AnimationState.laughing;
        }
        else if (happiness.getHappiness() >= 30)
        {
            state = AnimationState.sleeping;
        }
        else if(happiness.getHappiness() > 0)
        {
            state = AnimationState.bored;
        }
        else
        {
            BabyCry();
        }

        anim.SetInteger("state", (int)state);
    }

    private void BabyCry()
    {
        anim.SetTrigger("Cry");

        //kalan kodlar
    }

}
