namespace Mingems.Shared.Core.Enums
{
    public enum RecordState
    {
        Active,
        Removed
    }

    public enum Role
    {
        Admin,
        Customer
    }

    public enum SubscriptionStatus
    {
        NotPaid,
        Pending,
        Paid
    }

    public enum OrderStatus
    {
        Pending,
        Paid,
        Cancelled
    }

    public enum PaymentType
    {
        Cash,
        Card
    }
}