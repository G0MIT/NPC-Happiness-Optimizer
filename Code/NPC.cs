using System.Collections.Generic;

public class NPC {
  private const double LOVE_BUY_MODIFIER = 0.88;
  private const double LIKE_BUY_MODIFIER = 0.94;
  private const double DISLIKE_BUY_MODIFIER = 1.06;
  private const double HATE_BUY_MODIFIER = 1.12;

  private const double LOVE_SELL_MODIFIER = 1.14;
  private const double LIKE_SELL_MODIFIER = 1.06;
  private const double DISLIKE_SELL_MODIFIER = 0.94;
  private const double HATE_SELL_MODIFIER = 0.89;

  private const double SOLITUDE_BUY_MODIFIER = 0.95;
  private const double SOLITUDE_SELL_MODIFIER = 1.05;
  
  private const double CROWDED_BUY_MODIFIER = 1.05;
  private const double CROWDED_SELL_MODIFIER = 0.95;
  
  public string Name {get;}
  public int Value {get;}
  public Location CurrentLocation {get; set;}

  public double BuyModifier {get; private set;}
  public double SellModifier {get; private set;}
  
  public List<string> LovedNpcs {get;}
  public List<string> LikedNpcs {get;}

  public List<string> DislikedNpcs {get;}
  public List<string> HatedNpcs {get;}

  public List<string> LovedBiomes {get;}
  public List<string> LikedBiomes {get;}

  public List<string> DislikedBiomes {get;}
  public List<string> HatedBiomes {get;}
  
  public NPC(string name, int value, Location currentLocation,
    List<string> lovedNpcs, List<string> likedNpcs, List<string> dislikedNpcs, List<string> hatedNpcs,
    List<string> lovedBiomes, List<string> likedBiomes, List<string> dislikedBiomes, List<string> hatedBiomes) {
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

  public void calculateModifier() {
    calculateNPCModifier();
    calculateBiomeModifier();
  }

  private void calculateNPCModifier() {
    foreach (NPC npc in CurrentLocation.NPCs) {
      if (LovedNpcs.Contains(npc.Name)) {
        BuyModifier *= LOVE_BUY_MODIFIER;
        SellModifier *= LOVE_SELL_MODIFIER;
      } else if (LikedNpcs.Contains(npc.Name)) {
        BuyModifier *= LIKE_BUY_MODIFIER;
        SellModifier *= LIKE_SELL_MODIFIER;
      } else if (DislikedNpcs.Contains(npc.Name)) {
        BuyModifier *= DISLIKE_BUY_MODIFIER;
        SellModifier *= DISLIKE_SELL_MODIFIER;
      } else if (HatedNpcs.Contains(npc.Name)) {
        BuyModifier *= HATE_BUY_MODIFIER;
        SellModifier *= HATE_SELL_MODIFIER;
      }
    }
  }

  private void calculateBiomeModifier() {
    // TODO: Check biome priorities
    double bestSellModifier = double.MinValue;
    double bestBuyModifier = double.MaxValue;

    foreach (Biome biome in CurrentLocation.Biomes) {
      double currentSellModifier = 1.00;
      double currentBuyModifier = 1.00;
      
      if (LovedBiomes.Contains(biome.Name)) {
        currentBuyModifier = LOVE_BUY_MODIFIER;
        currentSellModifier = LOVE_SELL_MODIFIER;
      } else if (LikedBiomes.Contains(biome.Name)) {
        currentBuyModifier = LIKE_BUY_MODIFIER;
        currentSellModifier = LIKE_SELL_MODIFIER;
      } else if (DislikedBiomes.Contains(biome.Name)) {
        currentBuyModifier = DISLIKE_BUY_MODIFIER;
        currentSellModifier = DISLIKE_SELL_MODIFIER;
      } else if (HatedBiomes.Contains(biome.Name)) {
        currentBuyModifier = HATE_BUY_MODIFIER;
        currentSellModifier = HATE_SELL_MODIFIER;
      }

      if (currentSellModifier > bestSellModifier && currentBuyModifier < bestBuyModifier) {
        bestSellModifier = currentSellModifier;
        bestBuyModifier = currentBuyModifier;
      }
    }

    BuyModifier *= bestBuyModifier;
    SellModifier *= bestSellModifier;
  }
}