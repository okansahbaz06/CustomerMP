namespace CustomerMP.UI.Helper
{
    public class ExtraordinaryHelper
    {
        public static bool IsExtraordinary(string isim)
        {
            isim = isim.ToLower();
            string sesli = "aeıioöuü";

            int sayac = 0;
            for (int i = 0; i < isim.Length; i++)
            {
                if (sesli.Contains(isim[i]))
                {
                    sayac++;
                }
            }

            if (sayac > 3)
            {
                return true;
            }
            else
                return false;
        }
    }
}
