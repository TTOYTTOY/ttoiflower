using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPause = false; // �Ͻ� ���� �޴� â Ȱ��ȭ

    void Update()
    {
        //if (isOpenInventory || isOpenCraftManual || isOnComputer || isOpenArchemyTable || isPause)
        if (isPause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //canPlayerMove = false;
        }
    }
}
