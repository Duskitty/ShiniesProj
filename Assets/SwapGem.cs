using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapGem : MonoBehaviour
{
    function Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, hit, 100))
        {
            if (!noObj)//no object picked yet
            {
                noObj = hit.transform;//save picked objects transform
                tempObj = noObj.transform.position;
            }
            else if (noObj != null)
            { //if noObject now has a transform
                switchObj = hit.transform;
                DoTheSwitch();
            }
        }
    }

    function DoTheSwitch()
    {
        noObj.transform.position = switchObj.transform.position;//moves the first clicked object to the second clicke objects position
        switchObj.transform.position = tempObj;
        noObj = null;
    }
}
