namespace Infrastructure.Enum;

public enum EfCoreObserverEnum
{
    QUERY_COMPILED = 1,
    CONNECTION_OPENING = 2,
    CONNECTION_CLOSED = 3,
    QUERY_FAILED = 4,
    QUERY_Executed = 5,
    TRANSACTION_STARTED = 6,
    TRANSACTION_ROLLED_BACK = 7,
    TRANSACTION_COMMITTED = 8
}
