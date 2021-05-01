using UnityEngine;

namespace Specific.Location
{
    public static class IntroductoryMark // this is where to store and get the target mark when enter a scene
    {
        private static string _markName;
        public static string MarkName
        {
            set
            {
                _markName = value;
            }

            get
            {
                string temp = _markName;
                _markName = null;
                return temp;
            }
        }
    }
}

