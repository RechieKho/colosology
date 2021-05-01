using UnityEngine;
using Specific.Location;

namespace Specific
{
    public class ClearUp : MonoBehaviour
    {
        private void OnApplicationQuit()
        {
            SavePointManager.SaveSavePoint();
        }
    }

}
