using cc1_visitor.types;

InsuranceVisitor insuranceVisitor = new();

Console.WriteLine("What building do you want to visit ?");
while (true)
{
  string line = Console.ReadLine()?.Trim() ?? "";
  if (string.IsNullOrEmpty(line)) continue;

  if (BuildingKindHelper.FromString(line, out BuildingKind kind)) {
    Building building = kind switch
    {
      BuildingKind.BANK => new Bank(500000),
      BuildingKind.MUSEUM => new Museum(["La Nike de Samothrace", "Les Noces de Cana", "Les Tournesols"]),
      BuildingKind.SWIMMING_POOL => new SwimmingPool(5),
      _ => throw new NotImplementedException("huh This is not supposed to happen")
    };

    building.Accept(insuranceVisitor);
  } else {
    if (line == "exit" || line == "stop") break;

    Console.WriteLine($"'{line}' is not a valid building.");
  }

  Console.WriteLine("\nWhat building do you want to visit ?");
}
Console.WriteLine($"You visited {insuranceVisitor.VisitNumber} buildings !\n");
Console.WriteLine("Goodbye ♥♫");
