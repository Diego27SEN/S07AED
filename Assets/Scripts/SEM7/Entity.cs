using UnityEngine;

public class Entity : MonoBehaviour
{
    public string entityName;
    public EntityStats stats;

    public int ID => stats.id;
    public float Speed => stats.speed;

    public override string ToString()
    {
        return entityName + " ID " + ID + " Speed " + Speed;
    }
}