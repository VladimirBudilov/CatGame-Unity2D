using UnityEngine;

namespace _Scripts.NPC_s
{
    public class CatInventory : MonoBehaviour
    {
        [SerializeField] private bool hasKey = false;
        [SerializeField] private bool hasSpray = false;
        [SerializeField] private bool hasBread = false;

        public bool HasItem(string item)
        {
            switch (item)
            {
                case "hasKey": return hasKey;
                case "hasSpray": return hasSpray;
                case "hasBread": return hasBread;
            }

            return false;
        }

        public void GetItem(string item)
        {
            switch (item)
            {
                case "Key":
                {
                    hasKey = true;
                    break;
                }
                case "Spray":
                {
                    hasSpray = true;
                    break;
                }
                case "Bread":
                {
                    hasBread = true;
                    break;
                }
            }
        }
    }
}