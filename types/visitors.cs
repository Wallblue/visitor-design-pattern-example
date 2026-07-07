namespace cc1_visitor.types;

public abstract class Visitor()
{
  public int VisitNumber { get; protected set; } = 0;
  public void IncrementVisitNumber()
  {
    VisitNumber++;
  }
}

public interface IBuildingVisitor
{
  public void VisitBank(Bank bank);
  public void VisitMuseum(Museum museum);
  public void VisitSwimmingPool(SwimmingPool swimmingPool);
}

public class InsuranceVisitor : Visitor, IBuildingVisitor
{
  public void VisitBank(Bank bank)
  {
    Console.WriteLine($"Hi { bank.Name } we have a special insurance offer for { bank.Kind.ToEnglishString() }s.");
    Console.WriteLine($"We know you have { bank.moneyInTheSafeAmount } , we can provide safety against disasters or robery if needed !");
    this.IncrementVisitNumber();
  }

  public void VisitMuseum(Museum museum)
  {
    Console.WriteLine($"Hi { museum.Name } we have a special insurance offer for big { museum.Kind.ToEnglishString() }s like yours.");
    Console.WriteLine($"Your art collection is enormous, { museum.artCollection.Count } pieces of art ! {museum.artCollection[new Random().Next(0,2)]} is such a masterclass.");
    Console.WriteLine($"Our insurance for heritage protection would suit your affair perfectly.");
    this.IncrementVisitNumber();
  }

  public void VisitSwimmingPool(SwimmingPool swimmingPool)
  {
    Console.WriteLine($"Hi { swimmingPool.Name } we have a special insurance offer for water-ish establishment like your { swimmingPool.Kind.ToEnglishString() }.");
    Console.WriteLine($"We saw you had { swimmingPool.slideQuantity } great slides... You may not want to protect yourself from accidents accountability mh ?");
    this.IncrementVisitNumber();
  }
}
