using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform mainCam; // Tham chiếu đến camera chính
    public Transform midBg;   // Tham chiếu đến background chính
    public Transform sideBg;  // Tham chiếu đến background bên cạnh
    public float length;      // Khoảng cách di chuyển background

    // Update is called once per frame
    void Update()
    {
        // Nếu camera đi qua midBg thì cập nhật background
        if (mainCam.position.x > midBg.position.x)
        {
            UpdateBackgroundPosition(Vector3.right);
        }
        // Nếu camera đi ngược lại midBg thì cập nhật background
        else if (mainCam.position.x < midBg.position.x)
        {
            UpdateBackgroundPosition(Vector3.left);
        }
    }

    // Hàm cập nhật vị trí background
    void UpdateBackgroundPosition(Vector3 direction)
    {
        // Cập nhật vị trí sideBg
        sideBg.position = midBg.position + direction * length;

        // Hoán đổi midBg và sideBg
        Transform temp = midBg;
        midBg = sideBg;
        sideBg = temp;
    }
}

