using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCircle : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = this.transform.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.material.SetFloat("_StartTime", Time.time);

        float animationTime = _spriteRenderer.material.GetFloat("_AnimationTime");
        float destroyTime = animationTime;
        destroyTime -= _spriteRenderer.material.GetFloat("_StartWidth") * animationTime;
        destroyTime += _spriteRenderer.material.GetFloat("_Width") * animationTime;
        Destroy(transform.gameObject, destroyTime);
    }
}
