using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource secondaryMusic;
    private bool isPaused = false;

    void Start()
    {
        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isPaused)
        {
            StartCoroutine(PauseBackgroundForSeconds(0f));
        }
    }

    private IEnumerator PauseBackgroundForSeconds(float duration)
    {
        isPaused = true;
        backgroundMusic.Pause();

        if (secondaryMusic != null)
        {
            secondaryMusic.Play();
        }

        yield return new WaitForSeconds(duration);

        backgroundMusic.UnPause();
        isPaused = false;
    }
}
