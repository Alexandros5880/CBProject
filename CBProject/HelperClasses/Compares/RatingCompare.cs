using System.Collections.Generic;

namespace CBProject.HelperClasses.Compares
{
    public class RatingCompare : IComparer<float?>
    {
        public int Compare(float? x, float? y)
        {
            if (x == y)
                return 0;
            if (x == null)
                return 1;
            if (y == null)
                return -1;
            return x > y ? 1 : -1;
        }
    }
}