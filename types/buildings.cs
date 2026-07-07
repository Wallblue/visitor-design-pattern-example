using System.Text.RegularExpressions;

namespace cc1_visitor.types;

public enum BuildingKind
{
  BANK,
  MUSEUM,
  SWIMMING_POOL
}

public abstract class Building
{
  public abstract string Name { get; }
  public abstract BuildingKind Kind { get; }
  public abstract void Accept(Visitor visitor);
}

public class Bank(int moneyInTheSafeAmount) : Building
{
  public override string Name => "Societe Generale";
  public override BuildingKind Kind => BuildingKind.BANK;
  public int moneyInTheSafeAmount = moneyInTheSafeAmount;

  public override void Accept(Visitor visitor)
  {
    visitor.VisitBank(this);
  }
}

public class Museum(List<string> artCollection) : Building
{
  public override string Name => "Louvre";
  public override BuildingKind Kind => BuildingKind.MUSEUM;
  public List<string> artCollection = artCollection;

  public override void Accept(Visitor visitor)
  {
    visitor.VisitMuseum(this);
  }
}

public class SwimmingPool(short slideQuantity) : Building
{
  public override string Name => "Piscine de Palavas-les-flots";
  public override BuildingKind Kind => BuildingKind.SWIMMING_POOL;
  public short slideQuantity = slideQuantity;

  public override void Accept(Visitor visitor)
  {
    visitor.VisitSwimmingPool(this);
  }
}

public static partial class BuildingKindHelper
{
  public static string ToEnglishString(this BuildingKind kind)
  {
    return kind switch
    {
      BuildingKind.BANK => "bank",
      BuildingKind.MUSEUM => "museum",
      BuildingKind.SWIMMING_POOL => "swimming pool",
      _ => kind.ToString()
    };
  }

  public static bool FromString(string text, out BuildingKind result)
  {
    string cleanText = text.Trim().ToLower();
    cleanText = MyRegex().Replace(cleanText, "");

    switch (cleanText)
    {
      case "bank":
        result = BuildingKind.BANK;
        return true;
      case "museum":
        result = BuildingKind.MUSEUM;
        return true;
      case "swimmingpool":
        result = BuildingKind.SWIMMING_POOL;
        return true;
      default:
        result = default;
        return false;
    }
  }

  [GeneratedRegex("[^a-zA-Z0-9]")]
  private static partial Regex MyRegex();
}
