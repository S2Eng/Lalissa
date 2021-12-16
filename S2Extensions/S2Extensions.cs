using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2Extensions
{
    public static class S2Extensions
    {
    }

    public class Enums
    {
        public enum eCompareMode
        {
            Equals = 1,
            StartsWith = 2,
            Contains = 3,
            EndsWith = 4
        }
    }

    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static bool sEqualsList2(this List<object> s1, List<object> s2, Enums.eCompareMode compareMode = Enums.eCompareMode.Equals, bool trim = true, bool IgnoreCase = true)
        {
            try
            {
                foreach (object o1 in s1)
                {
                    foreach (object o2 in s2)
                    {
                        if (sEquals(o1, o2, compareMode, trim, IgnoreCase) == true)
                            return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("S2Extensions.sEquals (check list in list of objects): " + ex.ToString());
            }
        }

        public static bool sEquals(this object s1, List<object> s2, Enums.eCompareMode compareMode = Enums.eCompareMode.Equals, bool trim = true, bool IgnoreCase = true)
        {
            try
            {
                foreach (object o2 in s2)
                {
                    if (sEquals(s1, o2, compareMode, trim, IgnoreCase) == true)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("S2Extensions.sEquals (check object in list of objects): " + ex.ToString());
            }
        }

        public static bool sEquals(this object s1, object s2, Enums.eCompareMode compareMode = Enums.eCompareMode.Equals, bool trim = true, bool IgnoreCase = true)
        {
            try
            {
                if (trim)

                    switch (compareMode)
                    {
                        case Enums.eCompareMode.Equals:
                            return (s1.ToString() ?? "").Trim().Equals((s2.ToString() ?? "").Trim(), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.StartsWith:
                            return (s1.ToString() ?? "").Trim().StartsWith((s2.ToString() ?? "").Trim(), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.EndsWith:
                            return (s1.ToString() ?? "").Trim().EndsWith((s2.ToString() ?? "").Trim(), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.Contains:
                            return (s1.ToString() ?? "").Trim().IndexOf((s2.ToString() ?? "").Trim(), StringComparison.OrdinalIgnoreCase) >= 0;

                        default:
                            return false;
                    }
                else
                {
                    switch (compareMode)
                    {
                        case Enums.eCompareMode.Equals:
                            return (s1.ToString() ?? "").Equals((s2.ToString() ?? ""), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.StartsWith:
                            return (s1.ToString() ?? "").StartsWith((s2.ToString() ?? ""), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.EndsWith:
                            return (s1.ToString() ?? "").EndsWith((s2.ToString() ?? ""), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.Contains:
                            return (s1.ToString() ?? "").IndexOf((s2.ToString() ?? ""), StringComparison.OrdinalIgnoreCase) >= 0;

                        default:
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("S2Extensions.sEquals: " + ex.ToString());
            }
        }
    }
}
