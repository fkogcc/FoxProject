// �|�[�Y��ʂ��J�����鑀��.
// HACK:�|�[�Y��ʂ��G�ɍ�����̂ŃR�[�f�B���O�K�񂾂����Ăق���.

using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    // ����{�^��.
    private Button _close;
    // �e�X�g�{�^��.
    private Button _test;

    void Start()
    {
        // ���ꂼ��̃{�^���̃R���|�[�l���g�擾.
        _close = GameObject.Find("/PauseCanvs/BackGround/Close").GetComponent<Button>();
        _test = GameObject.Find("/PauseCanvs/BackGround/Test").GetComponent<Button>();

        _close.Select();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
