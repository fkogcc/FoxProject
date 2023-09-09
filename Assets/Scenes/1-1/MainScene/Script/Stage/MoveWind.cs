using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWind : MonoBehaviour
{
    [SerializeField]
    private float _windX = 0f;
    [SerializeField]
    private float _windY = 0f;
    [SerializeField]
    private float _windZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �g���K�[�͈̔͂ɓ����Ă���ԕ��̉e�����󂯂�
    /// </summary>
    /// <param name="other">�������Ă��鑊��</param>
    private void OnTriggerStay(Collider other)
    {
        // ���������I�u�W�F�N�g��RigidBody�擾
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();

        // rigidbody��null�ł͂Ȃ���
        if(rigidbody != null)
        {
            // �����rigidbody�ɗ͂�������
            rigidbody.AddForce(_windX, _windY, _windZ, ForceMode.Force);
        }
    }
}
