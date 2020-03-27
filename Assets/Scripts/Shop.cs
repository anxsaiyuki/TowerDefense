using System.Collections;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;

    BuildManager buildManager;
    // Singleton
    public static Shop instance;
  
    private Animator anim;

    void Awake() {
        if (instance != null) {
           Debug.Log("Singletion: More then one in scene");
            return;
        }
        instance = this;
    }

    void Start() {
        buildManager = BuildManager.instance;
        anim = gameObject.GetComponent<Animator>();
    }

    public void EnableShopMenu () {
        anim.SetBool("IsDisplayed", true);
    }

    public void DisableShopMenu () {
        anim.SetBool("IsDisplayed", false);
    }

    public void SelectStandardTurret()
    {

        PurchaseTurrent(standardTurret);
    }

    public void SelectMissileTurret()
    {
        PurchaseTurrent(missileTurret);
    }

    public void PurchaseTurrent(TurretBlueprint turret) {
        buildManager.setTurretToBuild(turret);
        buildManager.buildTurret();
        anim.SetBool("IsDisplayed", false);
    }
}
