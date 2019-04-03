using UnityEngine;

public class ButtonShow : MonoBehaviour
{
    public GameObject thisButton;
    public float _countdownTimer;

    private float timer;


    public void Start()
    {
        thisButton.SetActive(false);
        timer = _countdownTimer;
        InvokeRepeating("Countdown", 1.0f, 1.0f);
    }


    void Countdown()
    {
        if (--timer == 0.0f)
        {
            CancelInvoke("Countdown");
            thisButton.SetActive(true);
        }   
        else
        {
            Debug.Log("Countdowning");
            thisButton.SetActive(false);
        }

    }
}
