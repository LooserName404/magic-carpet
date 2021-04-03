using UnityEngine;

namespace MagicCarpet.Utils
{
    public static class Vector3Extensions
    {
        
        public static void Deconstruct(this Vector3 value, out float x, out float y, out float z)
        {
            x = value.x;
            y = value.y;
            z = value.z;
        }
        
        public static void Deconstruct(this Vector3 value, out float x, out float y)
        {
            x = value.x;
            y = value.y;
        }
    
    }
}