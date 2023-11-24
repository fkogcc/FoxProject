using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Red_Container : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleRed;
    [SerializeField] private ParticleSystem _particleGreen;
    [SerializeField] private ParticleSystem _particlePurple;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "stage2_kontena_red")
        {
            ContainerDirector._count++;
            EffectPlay();
        }
    }

    private void EffectPlay()
    {
        _particleRed.Play();
        _particleGreen.Play();
        _particlePurple.Play();
    }
}
