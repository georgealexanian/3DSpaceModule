using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EclipseChooseController : MonoBehaviour
{

    //will be used to save the choosen eclipse
    public EclipseDataController.EclipseInfo choosenEclipse { get; private set; }
    //will be used to trigger space setup behavior which will move bodies to
    //positions where they should be during the selected eclipse
    [SerializeField] private SetupViewAfterEclipseChosen setupViewAfterEclipseChosen;



    //called from inside the editor under the OnClick event of the "Row" Prefab
    public void EclipseChooser(int indexOfRowClicked)
    {
        Debug.Log($"An eclipse was chosen from the list at index {indexOfRowClicked}"); 

        //saving the choosen eclipse
        choosenEclipse = EclipseScrollViewController.foundEclipses[indexOfRowClicked - 1];
        //Debug.Log($"{choosenEclipse.latitude} {choosenEclipse.longitude}");

        //setting up Space to position bodies where they should be during the eclipse
        setupViewAfterEclipseChosen.StartSettingUpSceneToSimulateEclipse();
    }
}
