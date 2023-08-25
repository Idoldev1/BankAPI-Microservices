namespace UserServices_BankAPI;

public class ResponseModel
{
    public object? Result { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = "";
}