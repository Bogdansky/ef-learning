using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLearning.Infrastructure
{
    public static class Guard
    {
        public static void NotNull<T>(T value)
        {
            ArgumentNullException.ThrowIfNull(value);
        }
    }
}
