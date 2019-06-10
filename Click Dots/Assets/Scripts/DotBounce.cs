using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBounce : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    private void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
        StartCoroutine(RandomRotate());
    }

    public IEnumerator RandomRotate()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        transform.Rotate(0, 0, Random.Range(0, 360));
        if (transform.position.x > 380)
        {
            FindObjectOfType<SpawnDots>().loseAmount--;
            Destroy(gameObject);
        }
        else if (transform.position.x < -240)
        {
            FindObjectOfType<SpawnDots>().loseAmount--;
            Destroy(gameObject);
        }
        else if (transform.position.y > 300)
        {
            FindObjectOfType<SpawnDots>().loseAmount--;
            Destroy(gameObject);
        }
        else if (transform.position.y < -400)
        {
            FindObjectOfType<SpawnDots>().loseAmount--;
            Destroy(gameObject);
        }
        StartCoroutine(RandomRotate());
    }

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * moveSpeed;
    }
}
