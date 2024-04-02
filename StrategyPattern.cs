using System;

// Interfejs Strategii
public interface IDeliveryStrategy
{
    void Deliver();
}

// Konkretne strategie dostawy
public class CourierDeliveryStrategy : IDeliveryStrategy
{
    public void Deliver()
    {
        Console.WriteLine("Dostawa kurierem");
    }
}

public class InStorePickupStrategy : IDeliveryStrategy
{
    public void Deliver()
    {
        Console.WriteLine("Odbiór osobisty w sklepie");
    }
}

public class ElectronicsStore
{
    private IDeliveryStrategy _deliveryStrategy;

    public ElectronicsStore(IDeliveryStrategy deliveryStrategy)
    {
        _deliveryStrategy = deliveryStrategy;
    }

    public void SetDeliveryStrategy(IDeliveryStrategy deliveryStrategy)
    {
        _deliveryStrategy = deliveryStrategy;
    }

    public void Purchase()
    {
        Console.WriteLine("Produkt zakupiony. Metoda dostawy:");
        _deliveryStrategy.Deliver();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tworzymy sklep RTV
        ElectronicsStore electronicsStore = new ElectronicsStore(new InStorePickupStrategy());

        // Klient kupuje produkt z odbiorem osobistym
        electronicsStore.Purchase();

        // Zmieniamy metodę dostawy na dostawę kurierem
        electronicsStore.SetDeliveryStrategy(new CourierDeliveryStrategy());

        // Klient kupuje kolejny produkt z dostawą kurierem
        electronicsStore.Purchase();
    }
}
