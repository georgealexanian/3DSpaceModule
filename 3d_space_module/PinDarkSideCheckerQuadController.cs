using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinDarkSideCheckerQuadController : MonoBehaviour
{

    [SerializeField] private GameObject _parentSun;
    [SerializeField] private GameObject _pin;



    // Update is called once per frame
    void Update()
    {
        gameObject.transform.lookAt(_parentSun.transform);
        _pin.transform.LookAt(_parentSun.transform);
    }



    public void CheckIfPinIsOnDarkSideWithDelay()
    {
        Invoke("CheckIfPinIsOnDarkSide", 0.7f);
    }
    public void CheckIfPinIsOnDarkSide()
    {
        Ray raycast = new Ray(_pin.transform.position, _parentSun.transform.position);
        RaycastHit raycastHit;

        //sending a raycast to find out if a GameObject has been clicked
        if (Physics.Raycast(raycast, out raycastHit))
        {

            //if the clicked GameObject is the Sun
            if (raycastHit.collider.tag == "PinDarkSideChecker")
            {
                Debug.Log("On Dark Side Of Earth-----------------------------------");
            }
        }
    }

}
