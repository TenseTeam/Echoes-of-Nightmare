using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TreePrefabSwapper : MonoBehaviour
{
    //Fill this in the inspector with the prefabs to use in place of the tree prototypes defined in the Terrain object.
    public GameObject TreePrefab;

    [ContextMenu("SwapTrees")]
    private void SwapTrees()
    {
        var data = GetComponent<Terrain>().terrainData;

        foreach (var instance in data.treeInstances)
        {
            var tree = Instantiate(TreePrefab, instance.position, Quaternion.identity, transform);
            tree.transform.localScale = new Vector3(instance.widthScale, instance.heightScale, instance.widthScale);
        }
        data.treeInstances = new TreeInstance[0];
    }
}