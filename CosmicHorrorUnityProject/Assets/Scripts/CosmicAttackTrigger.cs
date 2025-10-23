using UnityEngine;

public class CosmicAttackTrigger : MonoBehaviour
{
    [HideInInspector]
    public CosmicAttackScript parentScript;
    public int laneIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (parentScript != null && other.CompareTag("Player"))
        {
            parentScript.OnPlayerEnterAttack(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (parentScript != null && other.CompareTag("Player"))
        {
            parentScript.OnPlayerExitAttack(other.gameObject);
        }
    }

    public void NotifyParentOfDestruction()
    {
        if (parentScript != null)
        {

            parentScript.OnAttackObjectDestroyed(laneIndex);
        }
    }
}