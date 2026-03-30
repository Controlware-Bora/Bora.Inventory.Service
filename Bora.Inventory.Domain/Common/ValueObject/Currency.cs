namespace Bora.Inventory.Domain.Common.ValueObject;

public class Currency
{
    #region Attributes
    
    public string Code { get; set; } = null!;
    public int DecimalPlaces { get; set; }

    #endregion
    #region Constructors
    
    // EF Core
    private Currency()
    {
    }

    public Currency(string code, int decimalPlaces)
    {
        Code = code;
        DecimalPlaces = decimalPlaces;
    }

    #endregion
    #region Methods

    public static Currency FromCode(string code)
    {
        code = code.Trim().ToUpper();
        return code switch
        {
            "USD" => new Currency("USD", 2),
            "PEN" => new Currency("PEN", 2),
            _ => throw new ArgumentException($"Invalid currency with value '{code}'")
        };
    }

    #endregion
    
}