using UnityEngine;

public class FloorName : MonoBehaviour
{
    // カメラの変更のために床の判定を取る.
    private StageCamera _camera;
    // 初期化処理.
    private void Start()
    {
        _camera = GameObject.Find("MinmapCamera").GetComponent<StageCamera>();
    }
    //  判定内.
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Player")
        {
            _camera.SetCameraName(this.gameObject.name);
        }
    }

    //  判定外.
    private void OnCollisionExit(Collision other)
    {
        // HACK テスト用で直接指定してる.
        _camera.SetCameraName("GameObject");
    }
}
