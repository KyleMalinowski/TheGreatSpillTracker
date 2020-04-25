﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGreatSpillsTracker.Data
{
    [Serializable]
    public class SpillData
    {
        private const string STRING_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public DateTime EnterpriseSpill { get; set; }
        public DateTime HomeSpill { get; set; }

        public DateTime RecordSpill { get; set; }
        public TimeSpan MaxTimeNoSpill { get; set; }

        public int SpillCount { get; set; }
        public int EnterpriseSpillCount { get; set; }
        public int HomeSpillCount { get; set; }
        public string PassHash { get; set; }
        public string HomeItemLastSpilled { get; set; }
        public string WorkItemLastSpilled { get; set; }
        public string RecordSpillItem { get; set; }

        public string EnterpriseSpillString()
        {
            return EnterpriseSpill.ToUniversalTime().ToString(STRING_FORMAT);
        }

        public string EnterpriseSpillStringNonUTC()
        {
            return EnterpriseSpill.ToString(STRING_FORMAT);
        }

        public string HomeSpillString()
        {
            return HomeSpill.ToUniversalTime().ToString(STRING_FORMAT);
        }

        public string HomeSpillStringNonUTC()
        {
            return HomeSpill.ToString(STRING_FORMAT);
        }

        public string RecordSpillString()
        {
            return RecordSpill.ToUniversalTime().ToString(STRING_FORMAT);
        }

        public string RecordSpillStringNonUTC()
        {
            return RecordSpill.ToString(STRING_FORMAT);
        }

        public TimeSpan TimeSinceLastSpill(DateTime spillTime)
        {
            DateTime lastSpill;
            if (EnterpriseSpill >= HomeSpill)
            {
                lastSpill = EnterpriseSpill;
            }
            else
            {
                lastSpill = HomeSpill;
            }

            return spillTime - lastSpill;
        }

        public void CheckSetNewRecord(DateTime spillTime)
        {
            TimeSpan timeSinceLastSpill = TimeSinceLastSpill(spillTime);

            if (timeSinceLastSpill > MaxTimeNoSpill)
            {
                MaxTimeNoSpill = timeSinceLastSpill;
            }
        }

    }
}
