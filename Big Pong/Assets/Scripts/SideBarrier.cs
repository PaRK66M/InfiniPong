using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBarrier : MonoBehaviour
{
    public bool isRightBarrier;

    public void Init(bool RightBarrier)
    {
        isRightBarrier = RightBarrier;
    }
}
