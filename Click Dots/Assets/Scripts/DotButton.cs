using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotButton : MonoBehaviour
{

    private void OnMouseDown()
    {
        if (gameObject.tag != "Bouncing")
        {
            FindObjectOfType<GameSessionManager>().score++;
            Destroy(gameObject);
        }
        else
        {
            FindObjectOfType<GameSessionManager>().score++;
            FindObjectOfType<GameSessionManager>().score++;
            Destroy(gameObject);
        }
    }
}
