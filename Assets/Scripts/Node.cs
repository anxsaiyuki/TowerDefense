using System.Collections;
using UnityEngine;

public class Node : MonoBehaviour
{
    BuildManager buildManager;
    Shop shop;
    public Color hoverColor;
    private Renderer rend;
    private Color startColor;
    public Color selectedColor;
    private bool selected = false;

    [Header("Optional")]
    public GameObject turret;

    void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
        shop = Shop.instance;
    }

    void OnMouseEnter() {
        if (!selected) {
            rend.material.color = hoverColor;
        }
    }

    void OnMouseExit() {
        if (!selected) {
            rend.material.color = startColor;
        }
    }

    public void setNodeColorReset() {
        rend.material.color = startColor;
        selected = false;
    }

    void OnMouseDown() {
        // Slide Menu
        shop.EnableShopMenu();
        // if (turret != null) {
        //   Debug.Log("Can't build there - TODO");
        //   return;
        // }
        rend.material.color = hoverColor;
        selected = true;
        buildManager.setCurrentNode(transform);
        // // Build a turret
        // GameObject turretToBuild = buildManager.getTurretToBuild();
        // turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    public void SetCurrentTurret(GameObject _turret)
    {
        turret = _turret;
    }
}

