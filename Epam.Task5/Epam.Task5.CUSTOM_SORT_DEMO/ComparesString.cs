namespace Epam.Task5.CUSTOM_SORT_DEMO
{
    public static class ComparesString
    {
        public static bool CompareString(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return true;
            }
            else if (a.Length < b.Length)
            {
                return false;
            }
            else if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a.ToCharArray()[i] > b.ToCharArray()[i])
                    {
                        return true;
                    }
                    else if (a.ToCharArray()[i] < b.ToCharArray()[i])
                    {
                        return false;
                    }
                }
            }

            return false;
        }
    }
}
