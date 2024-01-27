using UnityEngine;

public class Happiness : MonoBehaviour
{
    [SerializeField] private float happiness = 50f;
    [SerializeField] public float changeRate = 0.027f;
    private TimeController timeController;
    // %100 iken mutlu, %0 iken mutsuz.

    public float getHappiness()
    {
        return happiness;
    }

    private void checkHappiness()
    {
        if (happiness > 100f)
        {
            happiness = 100f;
        }
        else if (happiness < 0f)
        {
            happiness = 0f;
        }
    }

    public void setHappiness(float happiness)
    { 
        this.happiness = happiness; 
        checkHappiness();
    } 

    public void increaseHappiness(float happiness)
    {
        this.happiness += happiness;
        checkHappiness();
    }

    public void decreaseHappiness(float happiness)
    {
        this.happiness -= happiness;
        checkHappiness();
    }

    private void ChangeHappiness()
    {
        if (happiness >= 0f && happiness <= 100f)
        {
            decreaseHappiness(changeRate); 
        }
        else
        {
            checkHappiness();
        } 
    }

    void Start()
    {
        // lazým olursa doldurun.
        timeController = GameObject.Find("GameManager").GetComponent<TimeController>();
    }

    void FixedUpdate()
    {
        ChangeHappiness();

        TimerSpeedupOnHappiness();
    }

    private void TimerSpeedupOnHappiness()
    {
        if (timeController.getGameRunningState())
        {
            if (happiness >= 80f)
            {
                timeController.speedUp = 0.01f;
            }
            else if (happiness >= 30f)
            {
                timeController.speedUp = 0f;
            }
            //else
            //{
            //    timeController.speedUp = -0.1f;
            //}
        }
    }
}
