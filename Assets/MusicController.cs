using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    const int SPRING = 0;
    const int SUMMER = 1;
    const int AUTUMN = 2;
    const int WINTER = 3;

    public AudioSource[] songs;
    int season;

    float lastSeasonChangeTime;
    float lastUpdate;
    float timeToChange;

    // Start is called before the first frame update
    void Start()
    {
        season = SPRING;
        lastSeasonChangeTime = 0;
        timeToChange = 8;
        songs[SPRING].volume = 1;
        songs[SUMMER].volume = 0;
        songs[AUTUMN].volume = 0;
        songs[WINTER].volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.time - lastUpdate;
        if (Time.time - lastSeasonChangeTime < timeToChange)
        {
            float remainingTime = lastSeasonChangeTime + timeToChange - lastUpdate;
            for (int i = 0; i < songs.Length; i++)
            {
                if (season == i)
                {
                    songs[i].volume += (1 - songs[i].volume) * (deltaTime / remainingTime);
                }
                else
                {
                    songs[i].volume -= songs[i].volume * (deltaTime / remainingTime);
                }
            }
        }
        else
        {
            for (int i = 0; i < songs.Length; i++)
            {
                if (season == i)
                {
                    songs[i].volume = 1;
                } else
                {
                    songs[i].volume = 0;
                }
            }
        }
        lastUpdate = Time.time;
    }

    public void UpdateSeason()
    {
        season++;
        season %= 4;
        lastSeasonChangeTime = Time.time;
    }
}
