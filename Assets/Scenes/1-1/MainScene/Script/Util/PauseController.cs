using System.Collections;
using UnityEngine;
using UnityEngine.UI;// UI�R���|�[�l���g�d�l

public class PauseController : MonoBehaviour
{
    // ����{�^��
    private Button _close;
    // �e�X�g�{�^��
    private Button _test;

    // Start is called before the first frame update
    void Start()
    {
        _close = GameObject.Find("/PauseCanvs/BackGround/Close").GetComponent<Button>();
        _test = GameObject.Find("/PauseCanvs/BackGround/Test").GetComponent<Button>();

        _close.Select();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
