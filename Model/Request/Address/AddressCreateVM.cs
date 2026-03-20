namespace Dealership.Model.Request.Address;

public class AddressCreateRequest
{
    public required int UserId { get; set; }
    public required string Street { get; set; } //inicia com uma string vazia em vez de deixar null
    //evita nullReferenceException 
    public required string Number { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
}