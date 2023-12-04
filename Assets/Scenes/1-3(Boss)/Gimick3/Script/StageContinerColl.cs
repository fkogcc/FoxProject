using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageContinerColl : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleRed;
    [SerializeField] private ParticleSystem _particleGreen;
    [SerializeField] private ParticleSystem _particlePurple;
    [SerializeField] private GameObject _contena;
    [SerializeField] private GameObject _contenaGreen;
    [SerializeField] private ParticleSystem _contenaEffect;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject clone = Instantiate(_contenaGreen, this.transform.position, this.transform.rotation);
        _contenaEffect = clone.GetComponent<ParticleSystem>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag != "Gimick3_3")
        {
            Debug.Log(collision.gameObject.name + "    " + _contena.name);
            if (collision.gameObject.name == _contena.name)
            {
                ContainerDirector._getName = collision.gameObject.name;
                ContainerDirector._isColl = true;
                EffectPlay();
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.name == "stage2_kontena_green")
        //{
        ContainerDirector._getName = collision.gameObject.name;
        ContainerDirector._isColl = false;
        //}
    }
    // エフェクト再生
    private void EffectPlay()
    {
        _contenaEffect.Play();
        //_particleRed.Play();
        //_particleGreen.Play();
        //_particlePurple.Play();
    }
}
