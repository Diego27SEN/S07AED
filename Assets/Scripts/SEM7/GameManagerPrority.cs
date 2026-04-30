using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
public class GameManagerPrority : MonoBehaviour
{
    private enum PriorityType
    {
        MayorVelocidad,
        MenorID
    }
    private PriorityQueue<Entity> queue;
    private PriorityType priorityType;
    public Text orderText;

    [Button] // Crear cola
    public void CrearCola()
    {
        var entities = FindObjectsByType<Entity>(FindObjectsSortMode.None);

        queue = new PriorityQueue<Entity>((a, b) =>
        {
            if (priorityType == PriorityType.MayorVelocidad)
            {
                return a.Speed > b.Speed;
            }
            else
            {
                return a.ID < b.ID;
            }
        });

        foreach (var e in entities)
            queue.Enqueue(e);

        Debug.Log("Cola creada");
    }



    [Button] // Mostrar orden
    public void MostrarOrden()
    {
        if (queue == null) return;

        var list = queue.ToList();

        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log((i + 1) + ". " + list[i]);
        }
    }

    [Button] // Siguiente turno
    public void SiguienteTurno()
    {
        if (queue == null || queue.Count == 0) return;

        var turno = queue.Dequeue();
        Debug.Log("Turno: " + turno);
    }
    void ActualizarUI() // Mostrar orden en UI
    {
        if (queue == null) return;

        var list = queue.ToList();

        string texto = "";
        texto += "Criterio: " + priorityType + "\n\n";

        for (int i = 0; i < list.Count; i++)
        {
            texto += (i + 1) + ". " + list[i].gameObject.name + "\n";
        }

        orderText.text = texto;
    }


    [Button]
    public void MostrarOrdenUI()
    {
        ActualizarUI();
    }

}