using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer renderer;
    public Camera mainCamera;
    public GameObject Oven;
    private bool IsMouseEntered;
    

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
	    renderer.material.color = Color.red;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Déclare une variable de résultat de raycasting
        RaycastHit hit;

        // Teste si le rayon interagit avec le plan
        if (Physics.Raycast(ray, out hit))
        {
            // Obtient la position de l'impact
            Vector3 mousePositionOnPlane = hit.point;
            Vector3 realPosition = new Vector3((int)mousePositionOnPlane.x,mousePositionOnPlane.y,(int)mousePositionOnPlane.z);
            GameObject newLoots = Instantiate(Oven, realPosition, Quaternion.identity);

            // Affiche la position de la souris sur le plan dans la console
            Debug.Log("Position de la souris sur le plan : " + realPosition);
        }
        
                
    }

    


    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}