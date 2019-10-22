using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Television : Item
    {
        public string TvSize { get; set; }

        public string TvManuf { get; set; }

        public override string PrintInfo()
        {
            return $"{TvManuf} - {TvSize}";
        }
    }
}
