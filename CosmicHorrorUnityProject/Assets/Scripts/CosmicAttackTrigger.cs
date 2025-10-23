using UnityEngine;

public class CosmicAttackTrigger : MonoBehaviour
{
    [HideInInspector]
    public CosmicAttackScript parentScript;
<<<<<<< Updated upstream
    public int laneIndex;
=======
>>>>>>> Stashed changes

    private void OnTriggerEnter(Collider other)
    {
        if (parentScript != null && other.CompareTag("Player"))
        {
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

    public void NotifyParentOfDestruction()
    {
        if (parentScript != null)
        {

            parentScript.OnAttackObjectDestroyed(laneIndex);
        }
    }
=======
>>>>>>> Stashed changes
}