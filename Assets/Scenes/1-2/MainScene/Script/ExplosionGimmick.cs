using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGimmick : MonoBehaviour
{
    ExplosionGimmick _instance;

    [Header("�����ɓ����������ɐ�����ԗ͂̋���")]
    [SerializeField] private float _blastPower;

    [Header("�����̔��肪��������f�B���C")]
    [SerializeField] private float _startBlast;

    [Header("�����̎����t���[��")]
    [SerializeField] private int _durationFrame;

    [Header("�G�t�F�N�g�܂߂����ׂĂ̍Đ����I������܂ł̎���")]
    [SerializeField] private float _endEffectTime;

    // �p�[�e�B�N���I�u�W�F�N�g
    [Header("��������p�[�e�B�N���I�u�W�F�N�g���")]
    [SerializeField] private ParticleSystem _effect;

    // �ۂ̓����蔻��
    [Header("���̓����蔻��")]
    [SerializeField] private SphereCollider _collider;

    private void Awake()
    {
        // �V���O���g���̎���
        if( _instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _effect.Stop();
        _collider.enabled = false;
    }

    // ��������
    public void Explode()
    {
        // �����蔻��Ǘ��̃R���[�`��
    }
}
