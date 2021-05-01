using BayatGames.SaveGameFree;

namespace Specific
{
    public static class Setting
    {
        // Adjustable
        public static S_Parameter<float> mainVolume = new S_Parameter<float>("mainVolume");
        public static S_Parameter<float> effectVolume = new S_Parameter<float>("effectVolume");
        public static S_Parameter<float> bgmVolume = new S_Parameter<float>("bgmVolume");
        public static S_Parameter<float> detail = new S_Parameter<float>("detail");

        #region Method
        // static methods
        public static void LoadAllData() // load data from saved file
        {
            // sadness I can't find another way yet, so you gonna add stuff when new property is added
            mainVolume.LoadData();
            effectVolume.LoadData();
            bgmVolume.LoadData();
            detail.LoadData();
        }

        public static void SaveData() // save data to saved file
        {
            // sadness I can't find another way yet, so you gonna add stuff when new property is added
            mainVolume.SaveData();
            effectVolume.SaveData();
            bgmVolume.SaveData();
            detail.SaveData();
        }
        #endregion


        #region sub-class
        public class S_Parameter<T> where T : struct
        {
            public T value;
            public string _identifier;

            public S_Parameter(string __identifier)
            {
                _identifier = __identifier;
            }

            public void LoadData()
            {
                value = SaveGame.Load<T>(_identifier);
            }

            public void SaveData()
            {
                SaveGame.Save(_identifier, value);
            }
        }
        #endregion
    }
}