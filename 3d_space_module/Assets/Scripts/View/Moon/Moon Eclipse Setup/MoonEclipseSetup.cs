using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonEclipseSetup : MonoBehaviour
{

    //the sun
    [SerializeField] private GameObject _parentSun;
    //the pin which appears on Earth's surface when
    //a location is being chosen on its surface
    //to find eclipses
    [SerializeField] private GameObject _pin;
    //the moon
    [SerializeField] private GameObject _moon;
    //this is used to draw a line along which the Moon should be 
    //positioned to cast a shadow
    [SerializeField] private GameObject shadowCheckerObject;
    //used to switch the Moon light from the Moon onto the Pin
    [SerializeField] private MoonLightController moonLightController;
    //this is used to Set the Pin's position once again on Earth after 
    //it stops rotating
    [SerializeField] private PinController pinController;



    public void SetUpMoonToSimulateEclipse()
    {
        //drawing a line along which the Moon should be positioned
        DrawLineBetweenPinAndSun();
        //the Moon is positioned so that its shadow is cast upon
        //the chose eclipse location on Earth
        SetUpMoonPositionToCastShadow();
        //setting the Pin's position on Earth's surface once more
        pinController.ShowPinOnEarth(pinController.localPosition.x, pinController.localPosition.y, pinController.localPosition.z);
    }



    //this method repositions the Moon so that an eclipse can be simulated
    private void SetUpMoonPositionToCastShadow()
    {
        //the Moon's light now looks at the pin directly
        moonLightController.LightPinInsteadOfTheMoon();
        //this is the distance at which the Moon will
        //be set relative to Earth when casting its shadow on Earth
        float distanceOfMoonFromTheSun = _moon.transform.localPosition.y - _moon.transform.localPosition.y * 0.3f;
        //positioning the ShadowCheckerObject inside the Sun where it needs to be to draw a line from it toward the pin
        shadowCheckerObject.transform.position = new Vector3(_parentSun.transform.position.x + _pin.transform.localPosition.x, _pin.transform.position.y, _parentSun.transform.position.z);
        //first setting the Moon's position the same as the pin's so that later
        //it can be moved from that location along the shadow line
        _moon.transform.position = _pin.transform.position;
        //setting the Moon's position along the shadow line at a specific distance from the Earth
        //so that its shadow falls onto Earth upon the chosen eclipse location on its surface
        _moon.transform.position = Vector3.MoveTowards(_moon.transform.position, shadowCheckerObject.transform.position, distanceOfMoonFromTheSun);
    }



    //draws a straight line from the pin's center toward the Sun
    private void DrawLineBetweenPinAndSun()
    {
        Debug.DrawLine(_pin.transform.position, new Vector3(_parentSun.transform.position.x + _pin.transform.localPosition.x, _pin.transform.position.y, _parentSun.transform.position.z), Color.red, 1000f);
    }
}
