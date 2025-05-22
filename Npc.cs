using System.Collections.Generic;
namespace HappinessOptimizer
{
    public class Npc
    {
        protected const double LoveBuyModifier = 0.88;
        protected const double LikeBuyModifier = 0.94;
        protected const double DislikeBuyModifier = 1.06;
        protected const double HateBuyModifier = 1.12;

        protected const double LoveSellModifier = 1.14;
        protected const double LikeSellModifier = 1.06;
        protected const double DislikeSellModifier = 0.94;
        protected const double HateSellModifier = 0.89;

        private const double SolitudeBuyModifier = 0.95;
        private const double SolitudeSellModifier = 1.05;

        private const double CrowdedBuyModifier = 1.05;
        private const double CrowdedSellModifier = 0.95;

        protected const double MinBuyModifier = 1.50;
        protected const double MaxBuyModifier = 1.33;

        protected const double MaxSellModifier = 0.75;
        protected const double MinSellModifier = 0.67;

        public string Name { get; }
        public int Value { get; set; }
        public Location CurrentLocation { get; set; }

        public double BuyModifier { get; private set; }
        public double SellModifier { get; private set; }

        private readonly List<string> LovedNpcs;
        private readonly List<string> LikedNpcs;

        private readonly List<string> DislikedNpcs;
        private readonly List<string> HatedNpcs;

        private readonly List<string> LovedBiomes;
        private readonly List<string> LikedBiomes;

        private readonly List<string> DislikedBiomes;
        private readonly List<string> HatedBiomes;

        public Npc(string name, int value, Location currentLocation, List<string> lovedNpcs, List<string> likedNpcs, List<string> dislikedNpcs, List<string> hatedNpcs, List<string> lovedBiomes, List<string> likedBiomes, List<string> dislikedBiomes, List<string> hatedBiomes)
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

        public Npc(string name, Location currentLocation, List<string> lovedNpcs, List<string> likedNpcs, List<string> dislikedNpcs, List<string> hatedNpcs, List<string> lovedBiomes, List<string> likedBiomes, List<string> dislikedBiomes, List<string> hatedBiomes)
        {
            Name = name;
            Value = 0;
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

        public void CalculateModifier()
        {
            CalculateNPCModifier();
            CalculateBiomeModifier();
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
                if (LovedNpcs.Contains(npc.Name))
                {
                    BuyModifier *= LoveBuyModifier;
                    SellModifier *= LoveSellModifier;
                }
                else if (LikedNpcs.Contains(npc.Name))
                {
                    BuyModifier *= LikeBuyModifier;
                    SellModifier *= LikeSellModifier;
                }
                else if (DislikedNpcs.Contains(npc.Name))
                {
                    BuyModifier *= DislikeBuyModifier;
                    SellModifier *= DislikeSellModifier;
                }
                else if (HatedNpcs.Contains(npc.Name))
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

            foreach (Biome biome in CurrentLocation.Biomes)
            {
                double currentSellModifier = 1.00;
                double currentBuyModifier = 1.00;

                if (LovedBiomes.Contains(biome.Name))
                {
                    currentBuyModifier = LoveBuyModifier;
                    currentSellModifier = LoveSellModifier;
                }
                else if (LikedBiomes.Contains(biome.Name))
                {
                    currentBuyModifier = LikeBuyModifier;
                    currentSellModifier = LikeSellModifier;
                }
                else if (DislikedBiomes.Contains(biome.Name))
                {
                    currentBuyModifier = DislikeBuyModifier;
                    currentSellModifier = DislikeSellModifier;
                }
                else if (HatedBiomes.Contains(biome.Name))
                {
                    currentBuyModifier = HateBuyModifier;
                    currentSellModifier = HateSellModifier;
                }

                if (currentSellModifier > bestSellModifier && currentBuyModifier < bestBuyModifier)
                {
                    bestSellModifier = currentSellModifier;
                    bestBuyModifier = currentBuyModifier;
                }
            }

            BuyModifier *= bestBuyModifier;
            SellModifier *= bestSellModifier;
        }

        public int Score()
        {
            CalculateModifier();
            return (int) (Value / BuyModifier);
        }
    }
}