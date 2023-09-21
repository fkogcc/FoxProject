// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGimmick : MonoBehaviour
{
    // �V���O���g��
    public static FireGimmick _instance;

    // �p�[�e�B�N���I�u�W�F�N�g
    [SerializeField] private ParticleSystem _particleSystem;

    // �f�o�b�O�p�Q�[���I�u�W�F�N�g(Enemy)
    [SerializeField] private GameObject _debugEnemyObject;

    // �����R��������ő厞��
    [SerializeField] private float _burningMaxCount;

    // �����R�������Ă��鎞��
    private float _burningCount = 0;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem.Pause();
    }

    /// <summary>
    /// ���X�V����
    /// </summary>
    /// <param name="solve">�M�~�b�N�����������ǂ���</param>
    public void UpdateFire(bool solve)
    {
        if (!solve) return;
        // �p�[�e�B�N���Đ�
        _particleSystem.Play();

        // �R�������Ă��鎞�Ԃ𑫂�������
        if( _burningCount < _burningMaxCount )
        {
            _burningCount++;
        }

        // �R�������Ă��鎞�Ԃ��ő�l�Ɠ����ɂȂ�΃p�[�e�B�N���I��
        if(_burningCount == _burningMaxCount)
        {
            _particleSystem.Stop();
        }

        // �f�o�b�O�pEnemy����
        if(_burningCount == _burningMaxCount / 2)
        _debugEnemyObject.SetActive(false);
    }


}
