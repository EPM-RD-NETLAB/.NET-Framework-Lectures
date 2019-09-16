using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a flat with two bedrooms.
            Residence myFlat = new Residence(ResidenceType.Flat, 2);
            // Create a house with three bedrooms and a garage.
            Residence myHouse = new Residence(ResidenceType.House, 3, true);
            // Create a bungalow with two bedrooms, a garage, and a garden.
            Residence myBungalow = new Residence(ResidenceType.Bungalow, 2, true, true);

            // Create a house with three bedrooms and a garden.
            Residence myHouse1 = new Residence(ResidenceType.House, 3) { hasGarden = true };


            // Create a three-bedroom house.
            Residence myHouse2 = new Residence(ResidenceType.House, 3);
            // Indicate that the residence has a garden.
            myHouse.hasGarden = true;
            // Calculate the market value.
            int salePrice = myHouse.CalculateSalePrice();
            // Get the rebuilding costs.
            int rebuildCost = myHouse.CalculateRebuildingCost();
        }
    }
}
