using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

///Author James Sabila
///Practical Project 1
///<summary>
///This is the Model for the CSV Data - display only the requried field
///</summary>

namespace Project1.Model
{
    internal class DataModel
    {
        //private fields
        private string yearData;
        private string speciesData;
        private string commonNameData;
        private string studySiteData;
        private string associatedCommunityData;
        private string retinolData;


        //Getters and Setters to make it public
        [Name("Year/Ann�e")]
        public string year
        {
            get { return yearData; }
            set { yearData = value; }
        }
        [Name("Species/Esp�ce")]
        public string species
        {
            get { return speciesData; }
            set { speciesData = value; }
        }

        [Name("Common name/Nom commun")]
        public string commonName
        {
            get { return commonNameData; }
            set { commonNameData = value; }
        }

        [Name("Study site/Site d��tude")]
        public string studySite
        {
            get { return studySiteData; }
            set { studySiteData = value; }
        }

        [Name("Associated community/Collectivit� associ�e")]
        public string associatedCommunity
        {
            get { return associatedCommunityData; }
            set { associatedCommunityData = value; }
        }

        [Name("Retinol/R�tinol (mg/kg)")]
        public string retinol
        {
            get { return retinolData; }
            set { retinolData = value; }
        }            
    }
}
