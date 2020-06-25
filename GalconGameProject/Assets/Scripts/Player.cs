
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string Name;
    public string PlayerInfo;
    public float Percentage;

    List<Planet> AllPlanets;
    Dictionary<string, GameObject> SelectedPlanets;
    GameObject SelectedPlanet;

    private void Start()
    {
        AllPlanets = new List<Planet>();
        SelectedPlanets = new Dictionary<string, GameObject>();
    }

    RaycastHit hit;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print("mouse 0 clicked");
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 99999))
            {
                //print(string.Format("fired the ray One {0}", hit.transform.name));
                if (hit.transform.tag.Equals("Selectable"))
                {
                    //print("Hit One");
                    Selectable.SelectionState state = hit.transform.gameObject.GetComponent<Selectable>().CurrentState;
                    switch (state)
                    {
                        case Selectable.SelectionState.Selected:
                            if (!Input.GetKey(KeyCode.LeftShift))
                                DeselectAll();
                            else
                                Deselect(hit.transform.gameObject);
                            break;
                        case Selectable.SelectionState.Deselected:
                            if (!Input.GetKey(KeyCode.LeftShift))
                                DeselectAll();
                            Select(hit.transform.gameObject);
                            break;
                    }

                }
                else DeselectAll();
            }
        }
    }


    private void Select(GameObject gameObject)
    {
        gameObject.GetComponent<Selectable>().Select();
        AddToSelected(gameObject);
    }

    void DeselectAll()
    {
        if (SelectedPlanets.Count > 0)
            foreach (var item in SelectedPlanets)
                if (item.Value.GetComponent<Selectable>() != null)
                    item.Value.GetComponent<Selectable>().Deselect();

        SelectedPlanets.Clear();
    }
    void AddToSelected(GameObject ObjectToAdd)
    {
        SelectedPlanets.Add(ObjectToAdd.GetComponent<Planet>().Name, ObjectToAdd);
    }
    void Deselect(GameObject gameObject)
    {
        gameObject.GetComponent<Selectable>().Deselect();
        SelectedPlanets.Remove(gameObject.GetComponent<Planet>().Name);
    }
}
