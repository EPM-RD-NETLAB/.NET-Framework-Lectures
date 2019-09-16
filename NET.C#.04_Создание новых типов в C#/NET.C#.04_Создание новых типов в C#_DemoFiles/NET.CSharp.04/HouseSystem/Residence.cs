using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseSystem
{
    public enum ResidenceType
    {
        House,
        Flat,
        Bungalow,
        Apartment
    };

    public class Residence
    {
        public ResidenceType type;
        public int numberOfBedrooms;
        public bool hasGarage;
        public bool hasGarden;

        // Default constructor creates a 3-bedroom residence with a garage and a garden
        public Residence()
            : this(ResidenceType.House, 3, true, true)
        {
        }


        public Residence(ResidenceType type, int numberOfBedrooms)
        {
            this.type = type;
            this.numberOfBedrooms = numberOfBedrooms;
        }
        public Residence(ResidenceType type, int numberOfBedrooms, bool hasGarage)
        {
            this.type = type;
            this.numberOfBedrooms = numberOfBedrooms;
            this.hasGarage = hasGarage;
        }
        public Residence(ResidenceType type, int numberOfBedrooms, bool hasGarage, bool hasGarden)
        {
            this.type = type;
            this.numberOfBedrooms = numberOfBedrooms;
            this.hasGarage = hasGarage;
            this.hasGarden = hasGarden;
        }

        // Constructor to initialize the hasGarden field without setting hasGarage.(CTE!!!)
        //public Residence(ResidenceType type, int numberOfBedrooms,bool hasGarden)
        //{
        //    this.type = type;
        //    this.numberOfBedrooms = numberOfBedrooms;
        //    this.hasGarden = hasGarden;
        //}


        public int CalculateSalePrice()
        {
            // Code to calculate the sale value of the residence.
            throw new NotImplementedException();
        }

        public int CalculateRebuildingCost()
        {
            // Code to calculate the rebuilding costs of the residence.
            throw new NotImplementedException();
        }
    }
}