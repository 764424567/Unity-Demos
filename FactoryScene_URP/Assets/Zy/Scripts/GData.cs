namespace Com.Zcst.Zy
{
    /// <summary>
    /// 用户数据类
    /// </summary>
    public class GData
    {
        private static GData _instance;
        public static GData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GData();
                }
                return _instance;
            }
        }

        public bool isInto;

        private GData()
        {
            isInto = false;
        }
    }
}