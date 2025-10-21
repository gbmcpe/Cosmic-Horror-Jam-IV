using UnityEngine;

public class CosmicAttackTrigger : MonoBehaviour
{
    [HideInInspector]
    public CosmicAttackScript parentScript;

    private void OnTriggerEnter(Collider other)
    {
        if (parentScript == null) return;
        if (other.CompareTag("Player"))
        {
            parentScript.OnPlayerEnterAttack(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (parentScript == null) return;
        if (other.CompareTag("Player"))
        {
            parentScript.OnPlayerExitAttack(other.gameObject);
        }
    }
}