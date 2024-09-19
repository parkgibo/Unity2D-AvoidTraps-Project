using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainSound : MonoBehaviour
{
    [SerializeField] AudioSource Music;
    [SerializeField] float fadeDuration = 1.0f;  // Fade 시간 (초 단위)
    [SerializeField] float soundvoulume = 1.0f;  // Fade 시간 (초 단위)
    private bool isPlaying = false;  // 현재 음악이 재생 중인지 여부
    private MainSound mainSound;


    // Fade-in 코루틴 (음악 재생)
    public IEnumerator FadeIn()
    {
        Music.Play();
        float startVolume = 0f;
        Music.volume = startVolume;

        while (Music.volume < 0.5f)
        {
            Music.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }

        Music.volume = soundvoulume;
        isPlaying = true;
    }

    // Fade-out 코루틴 (음악 정지)
    public IEnumerator FadeOut()
    {
        float startVolume = Music.volume;

        while (Music.volume > 0f)
        {
            Music.volume -= Time.deltaTime / fadeDuration;
            yield return null;
        }

        Music.Stop();
        Music.volume = startVolume;
        isPlaying = false;
    }
    public void StopMusicOnPlayerCollision() // 적과 충돌 시 음악 정지
    {
        if (isPlaying)
        {
            StartCoroutine(FadeOut());
        }
    }
    public void OnMusic() //on버튼을 누르면 노래나옴
    {
        if (!isPlaying)
        {
            StartCoroutine(FadeIn());
        }
    }
    
}
