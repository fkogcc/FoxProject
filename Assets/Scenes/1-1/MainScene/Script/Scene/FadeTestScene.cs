using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTestScene : MonoBehaviour
{
    public GameObject ImgEnd;// 終了ダイアログ

    public Fade fade;// フェードキャンバス取得

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            ImgEnd.SetActive(true);// 終了ダイアログ呼び出し
        }
    }

    public void EndDialog(int Bt)
    {
        if(Bt == 0)
        {
            Application.Quit();
        }
        else
        {
            ImgEnd.SetActive(false);
        }
    }

    public void StartBt()
    {
        if(ImgEnd.activeSelf)
        {
            return;
        }

        fade.FadeIn(1f, () =>
        {
            SceneManager.LoadScene("Gimmick2Scene");
        });
    }
}
