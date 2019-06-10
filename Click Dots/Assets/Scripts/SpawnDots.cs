using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDots : MonoBehaviour
{
    [SerializeField] DotButton dotPrefab;
    [SerializeField] DotButton bouncingDotPrefab;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    public int loseAmount = 10;
    int randomAd;

    private void Start()
    {
        loseAmount = 10;
        loseText.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        StartCoroutine(CreateDots());
    }

    private IEnumerator CreateDots()
    {
        int dotChooser = Random.Range(0, 10);
        DotButton dotToSpawn = dotPrefab;
        if (dotChooser < 8)
        {
            dotToSpawn = dotPrefab;
        }
        else
        {
            dotToSpawn = bouncingDotPrefab;
        }
        var newDot = Instantiate(dotToSpawn, new Vector2(Random.Range(-10, 270), Random.Range(-190, 330)), Quaternion.identity);
        newDot.transform.parent = gameObject.transform;
        CheckIfLoseGame();
        yield return new WaitForSeconds(Random.Range(0.25f, 1f));
        StartCoroutine(CreateDots());
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void CheckIfLoseGame()
    {            
        if (transform.childCount > loseAmount)
        {
            StopAllCoroutines();
            loseText.SetActive(true);
        }
    }
}
