using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager1 : MonoBehaviour
{
    public MyQueue<string> BankQueue = new MyQueue<string>();

    void Start()
    {

    }

    [Button]
    public void Enqueue(string name)
    {
        BankQueue.Enqueue(name);
    }

    [Button]
    public void Dequeue()
    {
        Debug.Log("Pase a ser atendido:" + BankQueue.Dequeue());
    }

    [Button]
    public void Peek()
    {
        Debug.Log("El siguiente en ser atendido sera " + BankQueue.Peek());
    }

    [Button]
    public void Clear()
    {
        BankQueue.Clear();
    }
}