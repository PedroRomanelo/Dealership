namespace Dealership.Model.Request.Address;

public class AddressCreateRequest
{
    public int UserId { get; set; }
    public string Street { get; set; } = string.Empty; //inicia com uma string vazia em vez de deixar null
    //evita nullReferenceException 
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
}