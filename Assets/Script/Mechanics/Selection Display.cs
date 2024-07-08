using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public GameObject Plane; 
    private GameObject PlaneSelection; 
    private Vector3 realPosition;
    private bool Created = false; 
    private bool MachineCreated = false; 
    private bool isMouseOver = false; 
    private Camera mainCamera; 
    private Renderer renderer; 
    public Button MachineButton;
    public Button MachineButton1;
    public Button MachineButton2;
    public Button MachineButton3;


    public GameObject[] Oven;

    void Start()
    {
        mainCamera = Camera.main;
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isMouseOver && Input.GetMouseButtonDown(0))
        {
            
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // Déclare une variable de résultat de raycasting
            RaycastHit hit;

            // Teste si le rayon interagit avec le plan
            if (Physics.Raycast(ray, out hit))
            {
                // Obtient la position de l'impact
                
                Vector3 mousePositionOnPlane = hit.point;

                if (!Created || realPosition == new Vector3((int)mousePositionOnPlane.x, mousePositionOnPlane.y + 0.3f, (int)mousePositionOnPlane.z))
                {
                    realPosition = new Vector3((int)mousePositionOnPlane.x, mousePositionOnPlane.y + 0.3f, (int)mousePositionOnPlane.z);
                    PlaneSelection = Instantiate(Plane, realPosition, Quaternion.identity);

                    Created = true;
                }
                else
                {
                    if (PlaneSelection != null)
                    {
                        Destroy(PlaneSelection);
                        Created = false;
                        
                    }
                    Created = false;
                    MachineCreated = false;
                }

               
            }
        }
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        renderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    public void MachineCreation()
    {
        if(MachineButton.IsInteractable())
        {
            if (Created && !MachineCreated)
            {
                GameObject Machine = Instantiate(Oven[0], realPosition, Quaternion.identity);
                MachineCreated = true;

            }
            {

            }
        }

    }
    public void MachineCreation1()
    {
        if(MachineButton.IsInteractable())
        {
            if (Created && !MachineCreated)
            {
                GameObject Machine = Instantiate(Oven[1], realPosition, Quaternion.identity);
                MachineCreated = true;

            }
            {

            }
        }

    }
    public void MachineCreation2()
    {
        if(MachineButton.IsInteractable())
        {
            if (Created && !MachineCreated)
            {
                GameObject Machine = Instantiate(Oven[2], realPosition, Quaternion.identity);
                MachineCreated = true;

            }
            {
 
            }
        }

    }
    public void MachineCreation3()
    {
        if(MachineButton.IsInteractable())
        {
            if (Created && !MachineCreated)
            {
                GameObject Machine = Instantiate(Oven[3], realPosition, Quaternion.identity);
                MachineCreated = true;

            }
            {

            }
        }

    }
}
