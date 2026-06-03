using UnityEngine;

public class GateObstacle : MonoBehaviour
{
    public enum GateColor { Blue, Pink }
    public enum TriggerSide { Left, Right }

    [SerializeField] private GateColor gateColor;
    [SerializeField] private TriggerSide triggerSide;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        bool penalty = false;

        // Zilais → pareizi pa labi
        if (gateColor == GateColor.Blue && triggerSide == TriggerSide.Left)
            penalty = true;

        // Rozā → pareizi pa kreisi
        if (gateColor == GateColor.Pink && triggerSide == TriggerSide.Right)
            penalty = true;

        if (penalty)
        {
            Debug.Log("Nepareizā puse! +1 sekunde");
            GameManager.Instance.AddPenalty();
        }
    }
}