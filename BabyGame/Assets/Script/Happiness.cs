using UnityEngine;

public class Happiness : MonoBehaviour
{
    [SerializeField] private float happiness = 100f;
    [SerializeField] public float changeRate;
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
            Debug.Log($"DeltaTime: {Time.deltaTime}");
        }
        else
        {
            checkHappiness();
        }
    }

    void Start()
    {
        // lazım olursa doldurun.
    }

    void FixedUpdate()
    {
        ChangeHappiness();
    }
}
