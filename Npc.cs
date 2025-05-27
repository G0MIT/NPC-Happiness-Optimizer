using System;
using System.Collections.Generic;

namespace HappinessOptimizer
{
    public class Npc
    {
        protected const double LoveBuyModifier = 0.88, LikeBuyModifier = 0.94, DislikeBuyModifier = 1.06, HateBuyModifier = 1.12;

        protected const double LoveSellModifier = 1.14, LikeSellModifier = 1.06, DislikeSellModifier = 0.94, HateSellModifier = 0.89;

        private const double SolitudeBuyModifier = 0.95, SolitudeSellModifier = 1.05;

        private const double CrowdedBuyModifier = 1.05, CrowdedSellModifier = 0.95;

        protected const double MinBuyModifier = 0.75, MaxBuyModifier = 1.33;

        protected const double MaxSellModifier = 1.50, MinSellModifier = 0.67;

        public string Name { get; }
        public int Value { get; set; }
        public Location CurrentLocation { get; set; }

        public double BuyModifier { get; private set; }
        public double SellModifier { get; private set; }

        private readonly string[] LovedNpcs, LikedNpcs, DislikedNpcs, HatedNpcs;

        public string[] LovedBiomes { get; }
        public string[] LikedBiomes { get; }

        public string[] DislikedBiomes { get; }
        public string[] HatedBiomes { get; }

        public Npc(string name, int value, Location currentLocation, string[] lovedNpcs, string[] likedNpcs, string[] dislikedNpcs, string[] hatedNpcs, string[] lovedBiomes, string[] likedBiomes, string[] dislikedBiomes, string[] hatedBiomes)
        {
            Name = name;
            Value = value;
            CurrentLocation = currentLocation;

            BuyModifier = 1.00;
            SellModifier = 1.00;

            LovedNpcs = lovedNpcs;
            LikedNpcs = likedNpcs;

            DislikedNpcs = dislikedNpcs;
            HatedNpcs = hatedNpcs;

            LovedBiomes = lovedBiomes;
            LikedBiomes = likedBiomes;

            DislikedBiomes = dislikedBiomes;
            HatedBiomes = hatedBiomes;
        }

        public Npc(string name, string[] lovedNpcs, string[] likedNpcs, string[] dislikedNpcs, string[] hatedNpcs, string[] lovedBiomes, string[] likedBiomes, string[] dislikedBiomes, string[] hatedBiomes)
        {
            Name = name;
            Value = 0;
            CurrentLocation = null;

            BuyModifier = 1.00;
            SellModifier = 1.00;

            LovedNpcs = lovedNpcs;
            LikedNpcs = likedNpcs;

            DislikedNpcs = dislikedNpcs;
            HatedNpcs = hatedNpcs;

            LovedBiomes = lovedBiomes;
            LikedBiomes = likedBiomes;

            DislikedBiomes = dislikedBiomes;
            HatedBiomes = hatedBiomes;
        }

        public void CalculateModifier()
        {
            BuyModifier = 1.00;
            SellModifier = 1.00;
            CalculateNPCModifier();
            CalculateBiomeModifier();
            CalculateSolitudeModifier();
            if (BuyModifier > MaxBuyModifier)
            {
                BuyModifier = MaxBuyModifier;
            }
            else if (BuyModifier < MinBuyModifier)
            {
                BuyModifier = MinBuyModifier;
            }

            if (SellModifier < MinSellModifier)
            {
                SellModifier = MinSellModifier;
            }
            else if (SellModifier > MaxSellModifier)
            {
                SellModifier = MaxSellModifier;
            }
        }

        private void CalculateNPCModifier()
        {
            foreach (Npc npc in CurrentLocation.Npcs)
            {
                if (Array.Exists(LovedNpcs, element => element.Equals(npc.Name)))
                {
                    BuyModifier *= LoveBuyModifier;
                    SellModifier *= LoveSellModifier;
                }
                else if (Array.Exists(LikedNpcs, element => element.Equals(npc.Name)))
                {
                    BuyModifier *= LikeBuyModifier;
                    SellModifier *= LikeSellModifier;
                }
                else if (Array.Exists(DislikedNpcs, element => element.Equals(npc.Name)))
                {
                    BuyModifier *= DislikeBuyModifier;
                    SellModifier *= DislikeSellModifier;
                }
                else if (Array.Exists(HatedNpcs, element => element.Equals(npc.Name)))
                {
                    BuyModifier *= HateBuyModifier;
                    SellModifier *= HateSellModifier;
                }
            }
        }

        private void CalculateBiomeModifier()
        {
            // TODO: Check biome priorities
            double bestSellModifier = double.MinValue;
            double bestBuyModifier = double.MaxValue;
            bool modify = false;
            
            foreach (Biome biome in CurrentLocation.Biomes)
            {
                double currentSellModifier = 1.00;
                double currentBuyModifier = 1.00;

                if (Array.Exists(LovedBiomes, element => element.Equals(biome.Name)))
                {
                    currentBuyModifier = LoveBuyModifier;
                    currentSellModifier = LoveSellModifier;
                    modify = true;
                }
                else if (Array.Exists(LikedBiomes, element => element.Equals(biome.Name)))
                {
                    currentBuyModifier = LikeBuyModifier;
                    currentSellModifier = LikeSellModifier;
                    modify = true;
                }
                else if (Array.Exists(DislikedBiomes, element => element.Equals(biome.Name)))
                {
                    currentBuyModifier = DislikeBuyModifier;
                    currentSellModifier = DislikeSellModifier;
                    modify = true;
                }
                else if (Array.Exists(HatedBiomes, element => element.Equals(biome.Name)))
                {
                    currentBuyModifier = HateBuyModifier;
                    currentSellModifier = HateSellModifier;
                    modify = true;
                }

                if (currentSellModifier > bestSellModifier && currentBuyModifier < bestBuyModifier)
                {
                    bestSellModifier = currentSellModifier;
                    bestBuyModifier = currentBuyModifier;
                    modify = true;
                }
            }

            if (modify) {
                BuyModifier *= bestBuyModifier;
                SellModifier *= bestSellModifier;
            }
        }

        //TODO: Implement Solitude Modifier
        private void CalculateSolitudeModifier() {
            if (CurrentLocation.Npcs.Count <= 3) {
                BuyModifier *= SolitudeBuyModifier;
                SellModifier *= SolitudeSellModifier;
            } else {
                foreach ()
            }
        }
        public int Score()
        {
            CalculateModifier();
            // Console.WriteLine(Name + " has " + BuyModifier + " buy modifier.");
            return (int)(Value / BuyModifier);
        }
    }
}