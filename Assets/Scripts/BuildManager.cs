using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;

    public GameObject standardTurretPrefab;

    private Transform currentNode;
    public Vector3 positionOffset;

    void Awake() {
        if (instance != null) {
            Debug.Log("Singletion: More then one in scene");
            return;
        }
        instance = this;
    }

    public TurretBlueprint getTurretToBuild() {
        return turretToBuild;
    }

    public void setTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
    }

    public void setCurrentNode(Transform node) {
        if (currentNode != null) { 
            currentNode.GetComponent<Node>().setNodeColorReset();
        }
        currentNode = node;
    }

    public void buildTurret() {
        if (PlayerStats.Money < turretToBuild.cost) {
            Debug.Log("Not enough Money");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;

        Node nodeScript = currentNode.GetComponent<Node>();
        nodeScript.setNodeColorReset();
        nodeScript.SetCurrentTurret(turretToBuild.prefab);
        Instantiate(turretToBuild.prefab, currentNode.position + positionOffset, currentNode.rotation);

        Debug.Log("Money Left: " + PlayerStats.Money);
    }
}
