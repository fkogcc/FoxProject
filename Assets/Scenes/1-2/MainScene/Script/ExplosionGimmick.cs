using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGimmick : MonoBehaviour
{
    public static ExplosionGimmick _instance;

    // �p�[�e�B�N���I�u�W�F�N�g
    [SerializeField] ParticleSystem _particleSystem;

    // ���e�I�u�W�F�N�g
    [SerializeField] GameObject _bombObject;

    // �����̗^�����
    [SerializeField] private float _force;

    // �����͈͂̔��a
    [SerializeField] private float _radius;

    // ��ɔ�΂�����
    [SerializeField] private float _upwardsPower;

    // �p�[�e�B�N���̍ő�Đ�����
    [SerializeField] private float _particleMaxCount;

    // �p�[�e�B�N���Đ�����
    private float _particleCount;

    // ����������W
    Vector3 _ExplosionPosition;

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

        _particleSystem.Stop();
    }

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="solve">�M�~�b�N�����������ǂ���</param>
    public void UpdateExplosion(bool solve)
    {
        if(!solve) return;

        // �p�[�e�B�N���Đ�
        _particleSystem.Play();
        // �p�[�e�B�N�����W����
        _ExplosionPosition = _particleSystem.transform.position;

        // �͈͓���Rigidbody��AddExplosionForce
        // ��ŃR�����g�ύX
        Collider[] hitColliders = Physics.OverlapSphere(_ExplosionPosition, _radius);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            Rigidbody rigidbody = hitColliders[i].GetComponent<Rigidbody>();

            // �͈͓��ɂ���Rigidbody�����I�u�W�F�N�g�𐁂���΂�
            if(rigidbody)
            {
                rigidbody.AddExplosionForce(_force, _ExplosionPosition, _radius, _upwardsPower, ForceMode.Impulse);
            }
        }

        // �Đ����Ă��鎞��
        if(_particleCount < _particleMaxCount)
        {
            _particleCount++;
        }
        // ���Ԃ����ƃp�[�e�B�N���Đ��I��
        if(_particleCount == _particleMaxCount )
        {
            // �p�[�e�B�N���Đ��I��
            _particleSystem.Stop();
        }


        

        _bombObject.SetActive(false);
    }
}
