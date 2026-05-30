using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Model
{
    internal class DataModel
    {
        private string yearData;
        private string speciesData;
        private string commonNameData;
        private string studySiteData;
        private string associatedCommunityData;
        private string retinolData;

        public string year
        {
            get { return yearData; }
            set { yearData = value; }
        }

        public string species
        {
            get { return speciesData; }
            set { speciesData = value; }
        }

        public string commonName
        {
            get { return commonNameData; }
            set { commonNameData = value; }
        }

        public string studySite
        {
            get { return studySiteData; }
            set { studySiteData = value; }
        }

        public string associatedCommunity
        {
            get { return associatedCommunityData; }
            set { associatedCommunityData = value; }
        }

        public string retinol
        {
            get { return retinolData; }
            set { retinolData = value; }
        }
            
    }
}
