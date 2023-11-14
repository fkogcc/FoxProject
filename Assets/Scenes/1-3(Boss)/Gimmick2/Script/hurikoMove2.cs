using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurikoMove2 : MonoBehaviour
{
    GameObject Cube;

    private float rotateX = 0;


    private float rotateY = 0;


    private float rotateZ = 30;

    int count = 0;


    private void Start()
    {
        Cube = GameObject.Find("CubeRotate2");
    }

    void FixedUpdate()
    {
        count++;
        if (count < 75)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            Cube.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Mathf.Deg2Rad * 2);
        }
        else if (count < 225)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            Cube.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * -Mathf.Deg2Rad * 2);
        }
        else if (count < 300)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            Cube.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Mathf.Deg2Rad * 2);
        }
        else
        {
            count = 0;
        }

    }
}
