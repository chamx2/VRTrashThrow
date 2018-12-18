using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public Text _countdownText;
    public float _countdownTimer;

    private float timer;


    private void Start()
    {
        _countdownText.text = timer.ToString();
        timer = _countdownTimer;
        InvokeRepeating("Countdown", 1.0f, 1.0f);

    }

    void Countdown()
    {
        if (--timer == 0.0f)
        {
            CancelInvoke("Countdown");
            _countdownText.text = "Times Up!";
      

        }
        else
            _countdownText.text = timer.ToString();

    }
}
