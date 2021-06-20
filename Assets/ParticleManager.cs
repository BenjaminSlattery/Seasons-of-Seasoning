using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    const int SPRING = 0;
    const int SUMMER = 1;
    const int AUTUMN = 2;
    const int WINTER = 3;

    public ParticleSystemRenderer prenderer;
    public Material[] materials;

    int season;
    // Start is called before the first frame update
    void Start()
    {
        season = SPRING;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSeason()
    {
        season++;
        season %= 4;
        prenderer.material = materials[season];
    }
}
