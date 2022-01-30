using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    float timeCounter;
    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= 300)
        {
            if (MoralityManager.GetMoralityManager().Karma > 5)
            {
                SceneManager.LoadScene("GoodEnding");
            }
            else
            {
                SceneManager.LoadScene("BadEnding");
            }
        }
    }
}
