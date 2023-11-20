using UnityEngine;

// 機械(オブジェクト)を削除するスクリプト.
public class MachineDestory : MonoBehaviour
{
    // 溶岩を止めている壁の取得.
    private MoveWall _wall;

    // 初期化処理.
    void Start()
    {
        // 壁の取得.
        _wall = GameObject.Find("MoveWallDir").GetComponent<MoveWall>();
    }

    // Update is called once per frame
    void Update()
    {
        // 溶岩で満たされていたら.
        if (_wall.GetResult())
        {
            // オブジェクトの削除
            Destroy(this.gameObject);
        }
    }
}
