using BayatGames.SaveGameFree;

namespace Specific.Location
{
    public static class SavePointManager
    {
        private static SavePoint? _lastSavePoint;
        public static SavePoint LastSavePoint
        {
            set
            {
                _lastSavePoint = value;
            }

            get
            {
                return _lastSavePoint.GetValueOrDefault(GetSavedSavePoint());
            }
        }

        // Savepoint
        public static SavePoint GetSavedSavePoint()
        {
            return SaveGame.Load<SavePoint>("savepoint");
        }

        public static void SaveSavePoint()
        {
            SaveGame.Save("savepoint", LastSavePoint);
        }

        public static bool IsSavePointSaved()
        {
            return  SaveGame.Exists("savepoint");
        }

    }
    #region struct
    public struct SavePoint
    {
        public string scene;
        public string markName;

        public SavePoint(string __scene, string __markName)
        {
            scene = __scene;
            markName = __markName;
        }
    }
    #endregion
}

