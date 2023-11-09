/*シーン遷移マネージャー*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // タイトル.
    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // 1-1表世界.
    public void MainScene1_1()
    {
        SceneManager.LoadScene("MainScene1-1");
    }

    // 1-1-1ギミック.
    public void MainScene1_1_1()
    {
        SceneManager.LoadScene("Gimmick1_1_1Scene");
    }

    // 1-1-2ギミック.
    public void MainScene1_1_2()
    {
        SceneManager.LoadScene("Gimmick1_1_2Scene");
    }

    // 1-2表世界.
    public void MainScene1_2()
    {
        SceneManager.LoadScene("MainScene1-2");
    }

    // 1-2-1ギミック.
    public void MainScene1_2_1()
    {
        SceneManager.LoadScene("Gimmick1_2_1");
    }
    // 1-2-2ギミック.
    public void MainScene1_2_2()
    {
        SceneManager.LoadScene("Gimmick1_2_2");
    }

    // 1-2-3ギミック.
    public void MainScene1_2_3()
    {
        SceneManager.LoadScene("Gimmick1_2_3");
    }

    // 1-2-4ギミック.
    public void MainScene1_2_4()
    {
        SceneManager.LoadScene("Gimmick1_2_4");
    }

    // 1-3表世界.
    public void MainScene1_3()
    {
        SceneManager.LoadScene("MainScene1-3");
    }

    // 1-3-1ギミック.
    public void MainScene1_3_1()
    {
        SceneManager.LoadScene("Gimmick1_3_1");
    }

    // 1-3-2ギミック.
    public void MainScene1_3_2()
    {
        SceneManager.LoadScene("Gimmick1_3_2");
    }

    // 1-3-3ギミック.
    public void MainScene1_3_3()
    {
        SceneManager.LoadScene("Gimmick1_3_3");
    }

    // 1-3-4ギミック.
    public void MainScene1_3_4()
    {
        SceneManager.LoadScene("Gimmick1_3_4");
    }

    // エンドシーン.
    public void EndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
