namespace CentralCanteen
{
  /// <summary>
  /// Class for defining delivery parameters on an order. Extendable for more delivery options in the future.
  /// </summary>
  public class Delivery : Money
  {
    public int Cost { get => CalculateCost(); }
    private readonly float DeliveryFee = 5f; // Set value in dollars for the delivery fee. Accepts floating numbers (of course)
    public string Address;
    public bool Deliver;
    public string Label { get; }
    public string LocalizedCost { get => GetLocalizedCost(); }
    public string Localized { get => GetLocalized(); }

    /// <summary>
    /// Instantiates the Delivery object. First parameter is literally a verb that if provided false, sets all reference to this delivery as FREE.
    /// 
    /// Address is not in use such as calculating costs based on distance, etc. However, is used to save details where the order will be delivered. Also extendable in the future where Customer and Delivery Details may differ.
    /// </summary>
    /// <param name="Deliver">True to automatically add the delivery fee defined.</param>
    /// <param name="Address">The address to deliver the order.</param>
    public Delivery(bool Deliver, string Address = null)
    {
      this.Deliver = Deliver;

      if (this.Deliver)
      {
        this.Address = Address;
        Label = "Delivered";
      }
      else
      {
        Label = "Pickup";
      }
    }

    /// <summary>
    /// As mentioned, method is extendable in the future for distance based calculation for delivery costs
    /// </summary>
    /// <returns>The delivery cost (binary between free ($0) or the set delivery fee</returns>
    public int CalculateCost()
    {
      int NewCost = 0;
      float FloatNewCost = 0.0F;

      if (Deliver)
      {
        FloatNewCost = DeliveryFee * 100;
        NewCost = (int)FloatNewCost;
      }

      return NewCost;
    }

    /// <summary>
    /// Get the localized version of the delivery cost.
    /// </summary>
    /// <returns>The delivery cost in human readable format.</returns>
    public string GetLocalizedCost()
    {
      return Localize(Cost);
    }

    /// <summary>
    /// Get the localized details of the delivery method.
    /// </summary>
    /// <returns>The delivery method in text and the delivery costs</returns>
    public string GetLocalized()
    {
      string Localized = Label;

      if (Cost > 0)
      {
        Localized += " (" + GetLocalizedCost() + ")";
      }
      else
      {
        Localized += " (Free)";
      }

      return Localized;
    }
  }
}
